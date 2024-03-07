using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class DependenteService : ServiceBase, IDependenteService
    {
        private readonly IDependenteRepository _dependenteRepository;
        private readonly IRelacaoRepository _relacaoRepository;

        public DependenteService(IDependenteRepository dependenteRepository, IRelacaoRepository relacaoRepository, INotificador notificador) : base(notificador)
        {
            _dependenteRepository = dependenteRepository;
            _relacaoRepository = relacaoRepository;
        }
        public bool VerificarExisteConjuge(Guid socioId)
        {
            return _dependenteRepository.VerificarExisteConjuge(socioId);
        }
        public void Add(Dependente dependente)
        {
            var relacao = _relacaoRepository.GetById(dependente.RelacaoId);

            if (relacao != null)
            {
                if (relacao.Nome == "Cônjuge")
                {
                    if (VerificarExisteConjuge(dependente.SocioId))
                    {
                        Notificar("Já existe um Cônjuge para este Sócio.");
                        return;
                    }
                    _dependenteRepository.Add(dependente);
                }
                else if (relacao.Nome == "Filho")
                {
                    //Calcular a idade do filho
                    var idade = dependente.CalcularIdade(dependente.DataNascimento);

                    //Se o filho for maior de idade...
                    if (idade >= 18)
                    {
                        Notificar("Não é permitido o registro de filhos maior de idade.");
                        return;
                    }
                    _dependenteRepository.Add(dependente);
                }
            }
        }

        public IEnumerable<Dependente> BuscarTodos()
        {
            return _dependenteRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {
            Dependente dependente = GetById(id);
            if (dependente == null)
            {
                Notificar("O Agregado que pretende eliminar não existe.");
                return;
            }
            dependente.Status = false;
            Update(dependente);
        }

        public IEnumerable<Dependente> GetAll()
        {
            return _dependenteRepository.GetAll();
        }

        public Dependente GetById(Guid id)
        {
            return _dependenteRepository.GetById(id);
        }

        public void Update(Dependente dependente)
        {
            dependente.DataAtualizacao = DateTime.Now;
            _dependenteRepository.Update(dependente);
        }
        public void Dispose()
        {
            _dependenteRepository.Dispose();
        }

        public void Remove(Dependente dependente)
        {

            var novoDependente = _dependenteRepository.GetById(dependente.Id);
            if (novoDependente == null)
            {
                Notificar("O Dependente que pretende eliminar não existe.");
                return;
            }
            _dependenteRepository.Remove(novoDependente);
        }

		public IEnumerable<Dependente> BuscarAgregadoPorSocio(Guid socioId)
		{
            return _dependenteRepository.BuscarAgregadoPorSocio(socioId);
		}
	}
}
