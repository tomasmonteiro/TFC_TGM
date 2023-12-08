namespace CPF_CACL.GestaoSocio.Domain.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }
        public List<Notificacao> BuscarNotificacoes()
        {
            return _notificacoes;
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public bool HaNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
