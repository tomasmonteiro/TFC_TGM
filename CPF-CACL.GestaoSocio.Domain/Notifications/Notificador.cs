namespace CPF_CACL.GestaoSocio.Domain.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notification> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notification>();
        }
        public List<Notification> BuscarNotificacoes()
        {
            return _notificacoes;
        }

        public void Handle(Notification notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public bool HaNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
