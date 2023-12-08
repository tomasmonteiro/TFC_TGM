namespace CPF_CACL.GestaoSocio.Domain.Notifications
{
    public interface INotificador
    {
        bool HaNotificacao();
        List<Notificacao> BuscarNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
