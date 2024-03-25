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
        private readonly ICapitalRepository _capitalRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioSocioRepository _usuarioSocioRepository;
        public SocioService(IUsuarioRepository usuarioRepository, IUsuarioSocioRepository usuarioSocioRepository, ICapitalRepository capitalRepository, ISocioRepository socioRepository, IItemService itemService, IPeriodoService periodoService, ITipoItemRepository tipoItemRepository, INotificador notificador) 
            : base(notificador)
        {
            _socioRepository = socioRepository;
            _itemService = itemService;
            _periodoService = periodoService;
            _tipoItemRepository = tipoItemRepository;
            _capitalRepository = capitalRepository;
            _usuarioRepository = usuarioRepository;
            _usuarioSocioRepository = usuarioSocioRepository;
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
            //var novoSocio = _socioRepository.GetById(socio.Id);
            //novoSocio.CategoriaSocioId = socio.CategoriaSocioId;

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
            try
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

                //Criar um usuario para o Socio
                var usuario = new Usuario {
                    Nome = socio.Nome,
                    Email = socio.Email,
                    Login = socio.Cod,
                    Senha = "123456",
                    Perfil = Enums.EPerfilUsuario.Socio,
                    DataCriacao = DateTime.Now,
                    Status = true
                };
                _usuarioRepository.Add(usuario);

                //Crir o Usuario-Socio
                var usuarioSocio = new UsuarioSocio
                {
                    UsuarioId = usuario.Id,
                    SocioId = socio.Id,
                    DataCriacao = DateTime.Now,
                    Status = true
                };
                _usuarioSocioRepository.Add(usuarioSocio);

                return socio.Id;
            }
            catch (Exception erro)
            {
                Notificar("Ocorreu um erro: "+erro.Message.ToString());
                return Guid.Empty;
            }

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

        public double BuscarValorCapital(Guid socioId, Guid beneficioId)
        {
            var socio = _socioRepository.GetById(socioId);
            var categoriaId = socio.CategoriaSocioId;

            var capital = _capitalRepository.Find(p => p.BeneficioId == beneficioId && p.CategoriaSocioId == categoriaId && p.Status == true).FirstOrDefault();
            if (capital == null)
            {
                Notificar("Capital não localizado.");
                return 0;
            }

            return capital.Valor;
        }

		public Socio BuscarPorSemTrack(Guid socioId)
		{
            return _socioRepository.BuscarPorSemTrack(socioId);
		}
	}
}
