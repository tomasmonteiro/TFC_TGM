using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    public class SocioController : Controller
    {
        private readonly ISocioAppService _socioAppService;
        private readonly IBairroRepository _bairroRepository;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly ICategoriaSocioRepository _categoriaRepository;

        public SocioController(ISocioAppService socioAppService,  IBairroRepository bairroRepository, ICategoriaSocioRepository categoriaRepository, IMunicipioRepository municipioRepository)
        {
            _socioAppService = socioAppService;
            _bairroRepository = bairroRepository;
            _categoriaRepository = categoriaRepository;
            _municipioRepository = municipioRepository;
        }



        // GET: SocioController
        public ActionResult Index()
        {
            var socio = _socioAppService.Buscar();
            return View(socio);
        }

        // GET: SocioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            ViewBag.Municipios = municipios
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
            if (ModelState.IsValid)
            {

                _socioAppService.Adicionar(socio);
                return RedirectToAction("Index");
            }
            return View(socio);
        }

        // GET: SocioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SocioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
        public ActionResult Delete(int id)
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
        public IActionResult GetBairrosByMunicipio(int municipioId)
        {
            var bairros = _bairroRepository.BuscarPorMunicipio(municipioId);
            bairros = bairros.OrderBy(m => m.Nome).ToList();
            return Json(bairros);

        }




        //public IActionResult BuscarDados(int opcaoSelecionada)
        //{
        //  //var dados = _bairroRepository.BuscarPorMunicipio(opcaoSelecionada);

        //    var viewModel3 = new BairroViewModel();
        //    var dadosDaTabela = _bairroRepository.BuscarPorMunicipio(opcaoSelecionada);
        //    viewModel3.Municipio = dadosDaTabela
        //        .Select(item => new ItemDropDown
        //        {
        //            Id = item.Id,
        //            Nome = item.Nome
        //        })
        //        .ToList();


        //    return Json(viewModel3);
        //}
    }
}
