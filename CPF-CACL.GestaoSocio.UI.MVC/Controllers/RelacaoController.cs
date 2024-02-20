using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class RelacaoController : BaseController
    {
        private readonly IRelacaoAppService _relacaoAppService;
        public RelacaoController(IRelacaoAppService relacaoAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _relacaoAppService = relacaoAppService;
        }

        // GET: RelacaoController
        public ActionResult Index()
        {
            var relacao = _relacaoAppService.Buscar();

            return View(relacao);
        }


        // GET: RelacaoController/Criar
        public ActionResult Criar()
        {
            RelacaoViewModel rl = new RelacaoViewModel();
            return PartialView("Criar", rl);
        }

        // POST: RelacaoController/Criar
        [HttpPost]
        public ActionResult Criar(RelacaoViewModel viewModel)
        {
            try
            {
                var relacao = new RelacaoViewModel()
                {
                    Nome = viewModel.Nome,
                    DataCriacao = DateTime.Now,
                    Status = "true"
                };
                _relacaoAppService.Adicionar(relacao);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo adiciondo com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: RelacaoController/Editar/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: RelacaoController/Editar/5
        [HttpPost]
        public ActionResult Editar(Guid relacaoId, string Nome, DateTime dataCriacao, DateTime dataAtualizacao)
        {
            try
            {
                var relacao= new RelacaoViewModel()
                {
                    Id = relacaoId,
                    Nome = Nome,
                    DataCriacao = dataCriacao,
                    DataAtualizacao = dataAtualizacao
                };
                _relacaoAppService.Atualizar(relacao);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo actualizado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }


        // GET: RelacaoController/Deletar/5
        public ActionResult Deletar(int id)
        {
            return View();
        }

        // POST: RelacaoController/Deletar/5
        [HttpPost]
        public ActionResult Deletar(Guid id)
        {
            try
            {
                _relacaoAppService.Eliminar(id);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo eliminado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }
    }
}
