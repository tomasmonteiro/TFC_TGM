using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class AgregadoService : ServiceBase, IAgregadoService
    {
        private readonly IAgregadoRepository _agregadoRepository;
        private readonly IRelacaoRepository _relacaoRepository;

        public AgregadoService(IAgregadoRepository agregadoRepository, IRelacaoRepository relacaoRepository, INotificador notificador) : base(notificador)
        {
            _agregadoRepository = agregadoRepository;
            _relacaoRepository = relacaoRepository;
        }
        public bool VerificarExisteConjuge(Guid socioId)
        {
            return _agregadoRepository.VerificarExisteConjuge(socioId);
        }
        public void Add(Agregado agregado)
        {
            var relacao = _relacaoRepository.GetById(agregado.RelacaoId);

            if (relacao != null)
            {
                if (relacao.Nome == "Cônjuge")
                {
                    if (VerificarExisteConjuge(agregado.SocioId))
                    {
                        Notificar("Já existe um Cônjuge para este Sócio.");
                        return;
                    }
                    _agregadoRepository.Add(agregado);
                }
                else if (relacao.Nome == "Filho")
                {
                    //Calcular a idade do filho
                    var idade = agregado.CalcularIdade(agregado.DataNascimento);

                    //Se o filho for maior de idade...
                    if (idade >= 18)
                    {
                        Notificar("Não é permitido o registro de filhos maior de idade.");
                        return;
                    }
                    _agregadoRepository.Add(agregado);
                }
            }
        }

        public IEnumerable<Agregado> BuscarTodos()
        {
            return _agregadoRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {
            Agregado agregado = GetById(id);
            if (agregado == null)
            {
                Notificar("O Agregado que pretende eliminar não existe.");
                return;
            }
            agregado.Status = false;
            Update(agregado);
        }

        public IEnumerable<Agregado> GetAll()
        {
            return _agregadoRepository.GetAll();
        }

        public Agregado GetById(Guid id)
        {
            return _agregadoRepository.GetById(id);
        }

        public void Update(Agregado agregado)
        {
            agregado.DataAtualizacao = DateTime.Now;
            _agregadoRepository.Update(agregado);
        }
        public void Dispose()
        {
            _agregadoRepository.Dispose();
        }

        public void Remove(Agregado agregado)
        {
            _agregadoRepository.Remove(agregado);
        }

		public IEnumerable<Agregado> BuscarAgregadoPorSocio(Guid socioId)
		{
            return _agregadoRepository.BuscarAgregadoPorSocio(socioId);
		}
	}
}
