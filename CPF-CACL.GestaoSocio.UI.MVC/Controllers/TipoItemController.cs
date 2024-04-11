using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin")]
    public class TipoItemController : BaseController
    {
        private readonly ITipoEmolumentoRepository _tipoItemRepository;
        private readonly ITipoEmolumentoAppService _tipoItemAppService;
        //
        public TipoItemController(ITipoEmolumentoRepository tipoItemRepository, ITipoEmolumentoAppService tipoItemAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _tipoItemAppService = tipoItemAppService;
            _tipoItemRepository = tipoItemRepository;
        }

        // GET: TipoItemController
        public ActionResult Index()
        {
            var tipoItem = _tipoItemAppService.BuscarTodos();
            return View(tipoItem);
        }

        // GET: TipoItemController/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            return View();
        }

        // GET: TipoItemController/Create
        public ActionResult Criar()
        {
            TipoEmolumentoViewModel tipoItem = new TipoEmolumentoViewModel();
            return PartialView("Criar", tipoItem);
        }

        // POST: TipoItemController/Criar
        [HttpPost]
        public ActionResult Criar(TipoEmolumentoViewModel tipoItem)
        {
            try
            {
                _tipoItemAppService.Adicionar(tipoItem);

                //if (!ValidOperation())
                //{
                //    var sb = new StringBuilder();
                //    foreach (var item in BuscarMensagemErro())
                //    {
                //        sb.AppendLine($"x {item}\n");
                //    }
                //    return Json(sb.ToString());
                //}
                return Json("Registo adicionado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: TipoItemController/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: TipoItemController/Edit/5
        [HttpPost]
        public ActionResult Editar(Guid id, string Descricao, DateTime dataCriacao, DateTime dataAtualizacao)
        {
            try
            {
                var tipoItem = new TipoEmolumentoViewModel()
                {
                    Id = id,
                    Descricao = Descricao,
                    DataCriacao = dataCriacao,
                    DataAtualizacao = dataAtualizacao
                };
                _tipoItemAppService.Atualizar(tipoItem);

                //if (!ValidOperation())
                //{
                //    var sb = new StringBuilder();
                //    foreach (var item in BuscarMensagemErro())
                //    {
                //        sb.AppendLine($"x {item}\n");
                //    }
                //    return Json(sb.ToString());
                //}
                return Json("Registo actualizado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: TipoItemController/Delete/5
        public ActionResult Deletar(int id)
        {
            return View();
        }

        // POST: TipoItemController/Deletar/5
        [HttpPost]
        public ActionResult Deletar(Guid id)
        {
            try
            {
                _tipoItemAppService.Eliminar(id);
                return Json("Registo eliminado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }
    }
}
