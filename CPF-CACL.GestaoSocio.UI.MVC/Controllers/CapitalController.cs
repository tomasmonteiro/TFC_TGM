using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin")]
    public class CapitalController : BaseController
    {
        private readonly ICapitalAppService _capitalAppService;
        private readonly ICategoriaSocioRepository _categoriaRepository;
        private readonly IBeneficioRepository _beneficioRepository;
        public CapitalController(ICapitalAppService capitalAppService, ICategoriaSocioRepository categoriaRepository, IBeneficioRepository beneficioRepository, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _capitalAppService = capitalAppService;
            _categoriaRepository = categoriaRepository;
            _beneficioRepository = beneficioRepository;
        }

        public IActionResult Index()
        {
            var capital = _capitalAppService.BuscarTodosAtivos();
            return View(capital);
        }

        // GET: CapitalController/Detalhes/5
        public ActionResult Detalhes(Guid id)
        {
            var capital = _capitalAppService.BuscarPorId(id);
            return View(capital);
        }

        // GET: CapitalController/Criar
        public ActionResult Criar()
        {
            var viewModel = new CapitalViewModel();

            var categorias = _categoriaRepository.BuscarTodos();
            categorias = categorias.OrderBy(m => m.Nome).ToList();
            viewModel.Categoria = categorias
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();

            var beneficios = _beneficioRepository.BuscarTodos();
            beneficios = beneficios.OrderBy(m => m.Nome).ToList();
            viewModel.Beneficio = beneficios
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();


            return PartialView("Criar", viewModel);
        }

        // POST: BeneficioController/Criar
        [HttpPost]
        public ActionResult Criar(CapitalViewModel capital)
        {
            try
            {
                _capitalAppService.Adicionar(capital);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo adicionado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: CapitalController/Editar/5
        public ActionResult Editar(Guid id)
        {
            var capital = _capitalAppService.BuscarPorId(id);
            return View(capital);
        }

        // POST: CapitalController/Editar/5
        [HttpPost]
        public ActionResult Editar(CapitalViewModel capital)
        {
            try
            {
                _capitalAppService.Atualizar(capital);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: CapitalController/Eliminar/5
        [HttpPost]
        public ActionResult Eliminar(Guid id)
        {
            try
            {
                var capital = _capitalAppService.BuscarPorId(id);
                if (capital == null)
                {
                    return Json("O registo que pretende eliminar não foi localizado!");
                }
                else
                {
                    _capitalAppService.Eliminar(capital);

                    if (!ValidOperation())
                    {
                        var sb = new StringBuilder();
                        foreach (var item in BuscarMensagemErro())
                        {
                            sb.AppendLine($"x {item}\n");
                        }
                        return Json(sb.ToString());
                    }
                    return Json("Registo eliminado com sucesso!");
                }
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // POST: CapitalController/Inativar/5
        [HttpPost]
        public ActionResult Inativar(Guid id)
        {
            try
            {
                _capitalAppService.Inativar(id);

                if (!ValidOperation())
                {
                    var sb = new StringBuilder();
                    foreach (var item in BuscarMensagemErro())
                    {
                        sb.AppendLine($"x {item}\n");
                    }
                    return Json(sb.ToString());
                }
                return Json("Registo inativado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }
    }
}
