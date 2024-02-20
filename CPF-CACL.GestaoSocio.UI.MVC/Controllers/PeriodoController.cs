using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class PeriodoController : BaseController
    {
        private readonly IPeriodoAppService _periodoAppService;
        public PeriodoController(IPeriodoAppService periodoAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _periodoAppService = periodoAppService;
        }

        // GET: PeriodoController
        public ActionResult Index()
        {
            var periodos = _periodoAppService.BuscarTodos();
            return View(periodos);
        }

        // GET: PeriodoController/Detalhes/5
        public ActionResult Detailhes(int id)
        {
            return View();
        }

        // GET: PeriodoController/Criar
        public ActionResult Criar()
        {
            PeriodoViewModel periodo = new PeriodoViewModel();
            return PartialView("Criar", periodo);
        }

        // POST: PeriodoController/Criar
        [HttpPost]
        public ActionResult Criar(PeriodoViewModel periodo)
        {
            try
            {
                _periodoAppService.Adicionar(periodo);
                return Json("Registo adicionado com sucesso!");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // Ação para criar um período e automaticamente criar Quotas para os Sócios ativos
        [HttpPost]
        public ActionResult CriarPerioEItem(PeriodoViewModel periodo)
        {
            try
            {
                _periodoAppService.AdicionarPeriodoEItem(periodo);


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

        // GET: PeriodoController/Editar/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: PeriodoController/Editar/5
        [HttpPost]
        public ActionResult Editar(
            Guid id, 
            string codigo, 
            DateTime ano, 
            DateTime dataInicio, 
            DateTime dataFim,
            DateTime dataCriacao,
            DateTime dataAtualizacao
            )
        {
            try
            {
                var tipoItem = new PeriodoViewModel()
                {
                    Id = id,
                    Cod = codigo,
                    Ano = ano.Year,
                    DataInicio = dataInicio,
                    DataFim = dataFim,
                    DataCriacao = dataCriacao,
                    DataAtualizacao = dataAtualizacao
                };
                _periodoAppService.Atualizar(tipoItem);
                return Json("Registo actualizado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: PeriodoController/Deletar/5
        public ActionResult Deletar(int id)
        {
            return View();
        }

        // POST: PeriodoController/Deletar/5
        [HttpPost]
        public ActionResult Deletar(Guid id)
        {
            try
            {
                _periodoAppService.Eliminar(id);
                return Json("Registo eliminado com sucesso.");
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }
    }
}
