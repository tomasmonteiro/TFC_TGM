using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class SocioService : ServiceBase, ISocioService
    {
        private readonly ISocioRepository _socioRepository;
        private readonly IItemService _itemService;
        private readonly IPeriodoService _periodoService;
        private readonly ITipoItemRepository _tipoItemRepository;
        public SocioService(ISocioRepository socioRepository, IItemService itemService, IPeriodoService periodoService, ITipoItemRepository tipoItemRepository, INotificador notificador) 
            : base(notificador)
        {
            _socioRepository = socioRepository;
            _itemService = itemService;
            _periodoService = periodoService;
            _tipoItemRepository = tipoItemRepository;
        }

        public IEnumerable<Socio> BuscarPorNome(string nome)
        {
            return _socioRepository.BuscarPorNome(nome);
        }

        public IEnumerable<Socio> BuscarTodos()
        {
            return _socioRepository.BuscarTodos();
        }
        public void Add(Socio socio)
        {
            //if (!ExecutarValidacao(new SocioValidation(), socio)) return;
            if (_socioRepository.Find(a => a.Nome == socio.Nome && a.Status == true).Count() > 0)
            {
                Notificar("Já existe um Sócio definido com este nome.");
                return;
            }
            socio.EstadoSocio = Enums.EEstadoSocio.Pendente;
            _socioRepository.Add(socio);
        }
        public IEnumerable<Socio> GetAll()
        {
            return _socioRepository.GetAll();
        }
        public Socio GetById(Guid id)
        {
            return _socioRepository.GetById(id);
        }
        public void Update(Socio socio)
        {
            //if (!ExecutarValidacao(new SocioValidation(), socio)) return;
            socio.DataAtualizacao = DateTime.Now;
            _socioRepository.Update(socio);
        }
        public void Remove(Socio socio)
        {
            var novoSocio = _socioRepository.GetById(socio.Id);
            if (novoSocio == null)
            {
                Notificar("O Socio que pretende eliminar não existe.");
                return;
            }
            _socioRepository.Remove(novoSocio);
        }
        public void Eliminar(Guid id)
        {
            Socio socio = GetById(id);
            if (socio == null)
            {
                Notificar("O Sócio que pretende eliminar não existe.");
                return;
            }
            socio.Status = false;
            _socioRepository.Update(socio);
        }
        public void Dispose()
        {
            _socioRepository.Dispose();
        }

        public Socio BuscarPorCod(string codigo)
        {
            return _socioRepository.BuscarPorCodigo(codigo);
        }


        public Guid Adicionar(Socio socio)
        {
			socio.EstadoSocio = Enums.EEstadoSocio.Pendente;
			socio.Cod = GerarDodigoSocio();
            _socioRepository.Add(socio);

            //Criar codigo do perio
            var codPeriodo = _periodoService.GerarCodigoPeriodo(DateTime.Now);

            var periodo = _periodoService.BuscarPorCod(codPeriodo);

            var tipoItem = _tipoItemRepository.BuscarJoia();

            var item = new Item
            {
                Descricao = "Jóia",
                PeriodoId = periodo.Id,
                SocioId = socio.Id,
                TipoItemId = tipoItem.Id,
                DataCriacao = DateTime.Now,
                Status = true,
                Valor = 5000
            };
            //Adicionar Joia
            _itemService.Add(item);

            return socio.Id;
        }

        public string GerarDodigoSocio()
        {
            string tipoEntidade = "S";
            int anoAtual = DateTime.Now.Year % 100;

            var ultimoCodigo = _socioRepository.ConsultarUltimoCodigo(tipoEntidade, anoAtual);

            int proximoNumero = 1;

            if (ultimoCodigo != null)
            {
                proximoNumero = int.Parse(ultimoCodigo.Substring(2 + tipoEntidade.Length)) + 1;
            }
            return $"{tipoEntidade}{anoAtual:D2}{proximoNumero:D3}";
        }
    }
}
