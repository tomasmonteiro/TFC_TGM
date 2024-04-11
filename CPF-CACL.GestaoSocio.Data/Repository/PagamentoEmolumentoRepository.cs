using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class PagamentoEmolumentoRepository : RepositoryBase<PagamentoEmolumento>, IPagamentoEmolumentoRepository
    {
        private readonly IEmolumentoRepository _itemRepository;
        private readonly GSContext _gsContext;

        public PagamentoEmolumentoRepository(IEmolumentoRepository itemRepository, GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
            _itemRepository = itemRepository;
        }

        public IEnumerable<PagamentoEmolumento> BuscarItemPagamentoPorSocio(Guid socioId)
        {
            var itens = _gsContext.ItemPagamento
				.Include(p => p.Pagamento)
				.Include(p => p.Item)
				.Where(s => s.Status == true && s.Pagamento.SocioId == socioId).ToList();


            return itens;


        }

        public IEnumerable<PagamentoEmolumento> BuscarTodos()
        {
            return _gsContext.ItemPagamento.Where(p => p.Status == true);

        }

        public void CriarQuota(Socio socio, Periodo periodo)
        {
            //Busca o Tipo de Item "Quota"
            var tipoItem = _gsContext.TipoItem.Where(a => a.Descricao == "Quota" && a.Status == true).FirstOrDefault();

            //Cria as Quotas para os Sócios ativos

            var categoriaSocio = _gsContext.CategoriaSocio.Find(socio.CategoriaSocioId);
            var novoItem = new Emolumento
            {
                Codigo = GerarCodigoItem("Q"),
                Descricao = "Quota",
                Valor = categoriaSocio.Quota,
                DataVencimento = periodo.UltimoDiaUtil,
                DataCriacao = DateTime.Now,
                PeriodoId = periodo.Id,
                TipoItemId = tipoItem.Id,
                SocioId = socio.Id,
                Status = true
            };
            _itemRepository.Add(novoItem);

        }


        //Método para gerar o Código do Período
        public string GerarCodigoItem(string tipoItem)
        {
            int anoAtual = DateTime.Now.Year % 100;

            var ultimoCodigo = ConsultarUltimoCodigo(tipoItem, anoAtual);

            int proximoNumero = 1;

            if (ultimoCodigo != null)
            {
                proximoNumero = int.Parse(ultimoCodigo.Substring(2 + tipoItem.Length)) + 1;
            }

            return $"{tipoItem}{anoAtual:D2}{proximoNumero:D4}";
        }

        public string ConsultarUltimoCodigo(string tipoEntidade, int anoAtual)
        {
            var ultimoCodigo = _gsContext.Item
                .Where(p => p.Codigo.StartsWith($"{tipoEntidade}{anoAtual}"))
                .OrderByDescending(p => p.Codigo)
                .Select(p => p.Codigo)
                .FirstOrDefault();

            return ultimoCodigo;
        }


    }
}
