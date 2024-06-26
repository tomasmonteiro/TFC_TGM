﻿using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.Services;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.UI.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CPF_CACL.GestaoSocio.UI.MVC.Controllers
{
    [Autorizacao("Admin", "Presidente", "Tesoureiro", "Secretario", "Vogal")]
    public class SocioController : BaseController
    {
        private readonly ISocioAppService _socioAppService;
        private readonly ISocioRepository _socioRepository;
        private readonly IOrganismoRepository _organismoRepository;
        private readonly IBairroRepository _bairroRepository;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly ICategoriaSocioRepository _categoriaRepository;
        private readonly ISaldoAppService _saldoAppService;
        private readonly IEmolumentoAppService _itemAppService;
        private readonly IItemApoioAppService _itemApoioAppService;
		private readonly IDependenteAppService _agregadoAppService;

		public SocioController(IItemApoioAppService itemApoioAppService, ISocioAppService socioAppService, ISocioRepository socioRepository, IEmolumentoAppService itemAppService, IOrganismoRepository organismoRepository,  IBairroRepository bairroRepository, ICategoriaSocioRepository categoriaRepository, IMunicipioRepository municipioRepository, ISaldoAppService saldoAppService, IDependenteAppService agregadoAppService, INotificador notificador, IWebHostEnvironment env) : base(notificador, env)
        {
            _itemApoioAppService = itemApoioAppService;
            _socioAppService = socioAppService;
            _socioRepository = socioRepository;
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
            var idSocio = id;
            var idSaldo = id;
            var idItens = id;
            var idAgregado = id;


			//IEnumerable<PagamentoViewModel> pagamentos = _pagamentoAppService.BuscarDisponivel(id);
			IEnumerable<SaldoViewModel> saldos = _saldoAppService.BuscarDisponivel(idSaldo);
            ViewBag.Saldo = saldos;

            IEnumerable<EmolumentoViewModel> itens = _itemAppService.BuscarItemPorSocio(idItens);
			ViewBag.Itens = itens;

            IEnumerable<DependenteViewModel> agregado = _agregadoAppService.BuscarDependentePorSocio(idAgregado);
            IEnumerable<DependenteViewModel> agreg = agregado.Select(ag =>
            {
                if (ag.Genero == "F")
                {
                    ag.Genero = "Feminino";
                }
                else
                {
                    ag.Genero = "Masculino";
                }
                return ag;
            });
            ViewBag.Agregado = agreg;

			IEnumerable<ItemApoioViewModel> itemApoio = _itemApoioAppService.BuscarItemApoioPorSocio(idSocio);
			ViewBag.ItemApoio = itemApoio;

			var socio = _socioAppService.BuscarPorId(idSocio);
            if (socio.Genero == "F")
            {
                socio.Genero = "Feminino";
            }
            else 
            {
				socio.Genero = "Masculino";
			}

			var viewModel = new SocioViewModel();

			//Buscar Categorias para preencher o Select
			var categorias = _categoriaRepository.BuscarTodos();
			categorias = categorias.OrderBy(m => m.Nome).ToList();
			ViewBag.Cate = viewModel.CategoriaSocio
				= categorias
				.Select(item => new ItemDropDown
				{
					Id = item.Id,
					Nome = item.Nome
				})
				.ToList();



            var categoriaAtual = _categoriaRepository.GetById(socio.CategoriaSocioId);
            ViewBag.CategoriaNome = categoriaAtual.Nome;
			ViewBag.CategoriaId = categoriaAtual.Id;

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

            //Buscar Organismo para preencher o Select
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
				if (socio.Genero == "Feminino")
				{
					socio.Genero = "F";
				}
				else
				{
					socio.Genero = "M";
				}

				var novoSocioId = _socioAppService.Adicionar(socio);
				if (!ValidOperation())
				{
					var sb = new StringBuilder();
					foreach (var item in BuscarMensagemErro())
					{
						sb.AppendLine($"x {item}\n");
					}
					return Json(sb.ToString());
				}

				var mensagem = "Registo adicionado com sucesso.";
				var jsonData = new
				{
					novoSocioId,
					mensagem
				};
				return Json(jsonData);
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

        // GET: SocioController/Pesquisar/5
        public ActionResult Pesquisar(string codigo)
        {
            var socio = _socioRepository.BuscarPorCodigo(codigo);

            if (socio!= null)
            {
               return Json(new { socioId = socio.Id.ToString(), estado = socio.EstadoSocio.ToString() });
            }
            else
            {
                return Json($"Sócio não localizado!");
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

		// POST: SocioController/MudarCategoria
		[HttpPost]
		public ActionResult MudarCategoria(Guid SocioId, Guid NovaCategoria)
		{
			try
			{
				var socio = _socioAppService.BuscarPorSemTrack(SocioId);
                socio.CategoriaSocioId = NovaCategoria;
                _socioAppService.Atualizar(socio);

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
	}
}
