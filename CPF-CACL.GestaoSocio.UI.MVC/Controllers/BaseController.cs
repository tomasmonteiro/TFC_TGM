using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificador _notificador;
        private readonly IWebHostEnvironment _env;

        public BaseController(INotificador notificador, IWebHostEnvironment env)
        {
            _notificador = notificador;
            _env = env;
        }


        //Salvar Foto no servidor
        public string SalvarFoto(IFormFile foto)
        {
            string pastaUpload = Path.Combine(_env.WebRootPath, "IMG");
            string nomeArquivo = $"{Guid.NewGuid().ToString()}{Path.GetExtension(foto.FileName)}";
            string caminhoCompleto = Path.Combine(pastaUpload, nomeArquivo);
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                foto.CopyTo(stream);
            }
            return Path.Combine("IMG", nomeArquivo).Replace('\\','/');
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
            _notificador.Handle(new Notification(mensagem));
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
