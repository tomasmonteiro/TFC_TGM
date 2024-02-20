using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System.Globalization;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class PeriodoRepository : RepositoryBase<Periodo>, IPeriodoRepository
    {
        private readonly GSContext _gsContext;
        private readonly IItemRepository _itemRepository;
        int numeroItens = 0;
        public PeriodoRepository(IItemRepository itemRepository, GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
            _itemRepository = itemRepository;
        }

        //Método para adicionar um novo Período e automaticamente criar Quotas para todos os Sócios ativos
        public void AdicionarPeriodoEItem(Periodo novoPeriodo)
        {
            _gsContext.Periodo.Add(novoPeriodo);
            _gsContext.SaveChanges();

            //Busca os sócios ativos
            var sociosAtivos = _gsContext.Socio
                .Where(s => s.EstadoSocio == EEstadoSocio.Ativo && s.Status == true)
                .ToList();

            //Busca o Tipo de Item "Quota"
            var tipoItem = _gsContext.TipoItem.Where(a => a.Descricao == "Quota" && a.Status == true).FirstOrDefault();

           
            //Cria as Quotas para os Sócios ativos
            foreach (var socio in sociosAtivos)
            {
                var categoriaSocio = _gsContext.CategoriaSocio.Find(socio.CategoriaSocioId);
                var novoItem = new Item
                {
                    Cod = GerarDodigoItem("Q"),
                    Descricao = "Quota",
                    Valor = categoriaSocio.Quota,
                    DataVencimento = novoPeriodo.UltimoDiaUtil,
                    DataCriacao = DateTime.Now,
                    
                    PeriodoId = novoPeriodo.Id,
                    TipoItemId = tipoItem.Id,
                    SocioId = socio.Id,
                    Status = true
                };
                //_gsContext.Item.Add(novoItem);
                _itemRepository.Add(novoItem);
                numeroItens++;
            }
            
            //_gsContext.SaveChanges();
            //_gsContext.Clear();
            novoPeriodo.Id = Guid.Empty;
            numeroItens = 0;
        }

        //Método para gerar o Código do Período
        public string GerarDodigoItem(string tipoItem)
        {
            int anoAtual = DateTime.Now.Year % 100;

            var ultimoCodigo = ConsultarUltimoCodigo(tipoItem, anoAtual);

            int proximoNumero = 1;

            if (ultimoCodigo != null)
            {
                proximoNumero = int.Parse(ultimoCodigo.Substring(2 + tipoItem.Length)) + 1;
            }
            proximoNumero = proximoNumero + numeroItens;

            return $"{tipoItem}{anoAtual:D2}{proximoNumero:D4}";
        }

        public string ConsultarUltimoCodigo(string tipoEntidade, int anoAtual)
        {
            var ultimoCodigo = _gsContext.Item
                .Where(p => p.Cod.StartsWith($"{tipoEntidade}{anoAtual}"))
                .OrderByDescending(p => p.Cod)
                .Select(p => p.Cod)
                .FirstOrDefault();

            return ultimoCodigo;
        }

        public Periodo BuscarPorCod(string codigo)
        {
            return _gsContext.Periodo.Where(p => p.Cod == codigo).FirstOrDefault();
        }

        public IEnumerable<Periodo> BuscarTodos()
        {
            return _gsContext.Periodo.Where(p => p.Status == true);
        }

        public void SaveChanges()
        {
            _gsContext.SaveChanges();
        }
    }
}
