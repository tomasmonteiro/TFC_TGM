using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class NotificacaoRepository : RepositoryBase<Notificacao>, INotificacaoRepository
    {
        private readonly GSContext _gsContext;
        public NotificacaoRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }
    }
}
