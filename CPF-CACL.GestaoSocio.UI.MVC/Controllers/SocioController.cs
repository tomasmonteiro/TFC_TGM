using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class SocioController : BaseController
    {
        private readonly ISocioAppService _socioAppService;
        private readonly IOrganismoRepository _organismoRepository;
        private readonly IBairroRepository _bairroRepository;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly ICategoriaSocioRepository _categoriaRepository;
        private readonly ISaldoAppService _saldoAppService;
        private readonly IItemAppService _itemAppService;

		private readonly IAgregadoAppService _agregadoAppService;

		public SocioController(ISocioAppService socioAppService, IItemAppService itemAppService, IOrganismoRepository organismoRepository,  IBairroRepository bairroRepository, ICategoriaSocioRepository categoriaRepository, IMunicipioRepository municipioRepository, ISaldoAppService saldoAppService, IAgregadoAppService agregadoAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _socioAppService = socioAppService;
            _organismoRepository = organismoRepository;
            _bairroRepository = bairroRepository;
            _categoriaRepository = categoriaRepository;
            _municipioRepository = municipioRepository;
            _saldoAppService = saldoAppService;
            _itemAppService = itemAppService;
            _agregadoAppService = agregadoAppService;
        }



        // GET: SocioController
        public ActionResult Index()
        {
            

            var socio = _socioAppService.Buscar();
            return View(socio);
        }

        // GET: SocioController/Details/5
        public ActionResult Details(Guid id)
        {
            //IEnumerable<PagamentoViewModel> pagamentos = _pagamentoAppService.BuscarDisponivel(id);
            IEnumerable<SaldoViewModel> saldos = _saldoAppService.BuscarDisponivel(id);
            ViewBag.Saldo = saldos;

            IEnumerable<ItemViewModel> itens = _itemAppService.BuscarItemPorSocio(id);
			ViewBag.Itens = itens;

            IEnumerable<AgregadoViewModel> agregado = _agregadoAppService.BuscarAgregadoPorSocio(id);
            ViewBag.Agregado = agregado;

			var socio = _socioAppService.BuscarPorId(id);
            return View(socio);
        }

        // GET: SocioController/Create
        public ActionResult Create()
        {
            //Buscar os Bairros
            var viewModel = new SocioViewModel();
            
            var bairros = _bairroRepository.BuscarTodos();
            bairros = bairros.OrderBy(m => m.Nome).ToList();
            viewModel.Bairro = bairros
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();

            //Buscar Categorias para preencher o Select
            var organismos = _organismoRepository.BuscarTodos();
            organismos = organismos.OrderBy(m => m.Nome).ToList();
            ViewBag.Organismo = viewModel.Organismo
                = organismos
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();

            //Buscar Categorias para preencher o Select
            var categorias = _categoriaRepository.BuscarTodos();
            categorias = categorias.OrderBy(m => m.Nome).ToList();
            ViewBag.Categoria = viewModel.CategoriaSocio 
                = categorias
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();
            
            //Buscar Municipios
            var municipios = _municipioRepository.BuscarTodos();
            municipios = municipios.OrderBy(m => m.Nome).ToList();
            ViewBag.Municipios = viewModel.Municipio
                = municipios
                .Select(item => new ItemDropDown
                {
                    Id = item.Id,
                    Nome = item.Nome
                })
                .ToList();

            //return PartialView("Create", viewModel);

            return View("Create", viewModel);
        }


        // POST: SocioController/Create
        [HttpPost]
        public ActionResult Create(SocioViewModel socio )
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (socio.Foto != null)
                    {
                        socio.CaminhoFoto = SalvarFoto(socio.Foto);
                    }
                    
                    var novoSocioId = _socioAppService.Adicionar(socio);
                    var detalhesUrl = Url.Action("Details", new { id = novoSocioId });
                    //var resultado = Json( new { id = novoSocioId, url = detalhesUrl});
                    var mensagem = "Registo adicionado com sucesso.";
                    var jsonData = new
                    {
                        novoSocioId,
                        mensagem
                    };
                    return Json(jsonData);

                //}
                //return View(socio);
            }
            catch (Exception erro)
            {
                return Json($"x Ocorreu um erro: {erro.Message}");
            }
        }

        // GET: SocioController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: SocioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocioController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: SocioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        
        //Buscar Bairtros por Municipio
        [HttpGet]
        public IActionResult GetBairrosByMunicipio(Guid municipioId)
        {
            var bairros = _bairroRepository.BuscarPorMunicipio(municipioId);
            bairros = bairros.OrderBy(m => m.Nome).ToList();
            return Json(bairros);

        }
    }
}
