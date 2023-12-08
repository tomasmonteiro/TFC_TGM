using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool ValidOperation()
        {
            if (!_notificador.HaNotificacao()) return true;

            var notificacoes = _notificador.BuscarNotificacoes();
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));
            return false;
        }
        protected IEnumerable<string> BuscarMensagemErro()
        {
            return _notificador.BuscarNotificacoes().Select(c => c.Mensagem).ToList();
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validador = validacao.Validate(entity);

            if (validador.IsValid) return true;

            Notificar(validador);

            return false;
        }
    }
}
