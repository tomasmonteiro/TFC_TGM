﻿using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class ItemService : ServiceBase, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ITipoItemRepository _tipoItemRepository;
        private readonly ISocioRepository _socioRepository;
        private readonly IPeriodoRepository _periodoRepository;
        private readonly ICategoriaSocioRepository _categoriaSocioRepository;

        public ItemService(
            IItemRepository itemRepository, 
            ITipoItemRepository tipoItemRepository, 
            ISocioRepository socioRepository, 
            IPeriodoRepository periodoRepository,
            ICategoriaSocioRepository categoriaSocioRepository, 
            INotificador notificador
            ) : base(notificador)
        {
            _itemRepository = itemRepository;
            _tipoItemRepository = tipoItemRepository;
            _socioRepository = socioRepository;
            _periodoRepository = periodoRepository;
            _categoriaSocioRepository = categoriaSocioRepository;
        }

        public void Add(Item item)
        {
            try
            {
                if (_itemRepository.Find(
                    a => a.Descricao == item.Descricao 
                    && 
                    a.PeriodoId == item.PeriodoId 
                    && 
                    a.SocioId == item.SocioId 
                    && a.Status == true
                    ).Count() > 0)
                {
                    Notificar("Já existe um Item com esta Descrição.");
                    return;
                }
                //Buscar o Tido de Item
                var tipoItem = _tipoItemRepository.GetById(item.TipoItemId);
                if (item.Descricao == null)
                {
                    item.Descricao = tipoItem.Descricao;
                }


                if (tipoItem.Descricao == "Inscrição")
                {
                    item.Cod = GerarCodigoItem("INS");
                    _itemRepository.Add(item);
                }
                else if (tipoItem.Descricao == "Jóia")
                {
                    item.Cod = GerarCodigoItem("JOI");
                    _itemRepository.Add(item);
                }
                else if (tipoItem.Descricao == "Quota")
                {
                    var periodo = _periodoRepository.GetById(item.PeriodoId);
                    var socio = _socioRepository.GetById(item.SocioId);
                    var categoriaSocio = _categoriaSocioRepository.GetById(socio.CategoriaSocioId);

                    //Calcular a data de vencimento (10º dia útil) com base na data inicial do periodo
                    item.DataVencimento = CalcularDiaUtil(periodo.DataInicio);


                    item.Valor = categoriaSocio.Quota;
                    item.Cod = GerarCodigoItem("QUO");
                    _itemRepository.Add(item);
                }
                else if (tipoItem.Descricao == "Multa")
                {
                    item.Cod = GerarCodigoItem("MUL");
                    _itemRepository.Add(item);
                }
                else
                {
                    //Outros pagamentos
                    item.Cod = GerarCodigoItem("OUT");
                    _itemRepository.Add(item);
                }

            }
            catch (Exception erro)
            {
                Notificar("Ocorreu um erro: "+ erro.Message.ToString());
                return;
            }



            //Gerar Multa

            //var tipoItem = _tipoItemRepository.GetById(item.TipoItemId);

            ////Gerar multa em caso de a data limite de pagamento já tenha excedido
            //if (tipoItem.Descricao == "Quota")
            //{
            //    var socio = _socioRepository.GetById(item.SocioId);
            //    var categoriaSocio = _categoriaSocioRepository.GetById(socio.CategoriaSocioId);

            //    var novoItem = new Item
            //    {
            //        Descricao = "Multa",
            //        Valor = (10 * categoriaSocio.Quota / 100),//Calcular os 10% de multa
            //        Estado = Enums.EEstadoItem.NaoPago,
            //        DataVencimento = null,
            //        PeriodoId = item.PeriodoId
            //    };

            //}
        }
        public string GerarCodigoItem(string tipoItem)
        {
            int anoAtual = DateTime.Now.Year % 100;

            var ultimoCodigo = _itemRepository.ConsultarUltimoCodigo(tipoItem, anoAtual);

            int proximoNumero = 1;

            if (ultimoCodigo != null)
            {
                proximoNumero = int.Parse(ultimoCodigo.Substring(2 + tipoItem.Length)) + 1;
            }
            return $"{tipoItem}{anoAtual:D2}{proximoNumero:D4}";
        }
        private DateTime CalcularDiaUtil(DateTime data)
        {
            int diasUteisEncontrados = 0;
            DateTime dataAtual = new DateTime(data.Year, data.Month, 1);

            while (diasUteisEncontrados < 10)
            {
                //Verifica se é sábado ou domingo
                if (dataAtual.DayOfWeek != DayOfWeek.Saturday 
                    &&
                    dataAtual.DayOfWeek != DayOfWeek.Sunday
                    )
                {
                    diasUteisEncontrados++;
                }
                //Avança para o próximo dia
                dataAtual = dataAtual.AddDays(1);
            }
            //Retorna o décimo dia útil
            return dataAtual.AddDays(-1);
        }




        public IEnumerable<Item> BuscarItemNPago()
        {
            return _itemRepository.BuscarItemNPago();
        }
        public IEnumerable<Item> BuscarItemPago()
        {
            return _itemRepository.BuscarItemPago();
        }
        public IEnumerable<Item> BuscarPorItemTipo(Guid idTipoItem)
        {
            return _itemRepository.BuscarPorTipoItem(idTipoItem);
        }
        public IEnumerable<Item> BuscarTodos()
        {
            return _itemRepository.BuscarTodos();
        }
        public Item GetById(Guid id)
        {
            return _itemRepository.GetById(id);
        }
        public void Eliminar(Guid id)
        {
            var item = _itemRepository.GetById(id);
            if (item == null)
            {
                Notificar("O Item que pretende eliminar não existe.");
                return;
            }
            item.Status = false;
            Update(item);
        }
        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }
        public void Update(Item item)
        {
            item.DataAtualizacao = DateTime.Now;
            _itemRepository.Update(item);
        }
        public void Remove(Item item)
        {
            var novoItem = _itemRepository.GetById(item.Id);
            if (novoItem == null)
            {
                Notificar("O Item que pretende eliminar não existe.");
                return;
            }
            _itemRepository.Remove(novoItem);
        }
        public void Dispose()
        {
            _itemRepository.Dispose();
        }
        public Item BuscarPorCod(string codigo)
        {
            return _itemRepository.BuscarPorCod(codigo);
        }

		public IEnumerable<Item> BuscarItemPorSocio(Guid socioId)
		{
            return _itemRepository.BuscarItemPorSocio(socioId);
		}
	}
}
