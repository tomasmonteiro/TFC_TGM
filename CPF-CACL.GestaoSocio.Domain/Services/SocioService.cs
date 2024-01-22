using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class SocioService : ServiceBase, ISocioService
    {
        private readonly ISocioRepository _socioRepository;
        public SocioService(ISocioRepository socioRepository, INotificador notificador) 
            : base(notificador)
        {
            _socioRepository = socioRepository;
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
            _socioRepository.Remove(socio);
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
            socio.Cod = GerarDodigoSocio();
            _socioRepository.Add(socio);
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
