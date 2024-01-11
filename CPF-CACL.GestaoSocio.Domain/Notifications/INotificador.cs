namespace CPF_CACL.GestaoSocio.Domain.Notifications
{
    public interface INotificador
    {
        bool HaNotificacao();
        List<Notification> BuscarNotificacoes();
        void Handle(Notification notificacao);
    }
}
