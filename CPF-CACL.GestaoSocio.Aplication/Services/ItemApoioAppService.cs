using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
	public class ItemApoioAppService : IItemApoioAppService
	{

		private readonly IMapper mapper;
		private readonly IItemApoioService itemApoioService;

		public ItemApoioAppService(IItemApoioService itemApoioService, IMapper mapper)
		{
			this.mapper = mapper;
			this.itemApoioService = itemApoioService;
		}

		public IEnumerable<ItemApoioViewModel> BuscarItemApoioPorSocio(Guid socioId)
		{
			var itens = itemApoioService.BuscarItemApoioPorSocio(socioId);

			return mapper.Map<IEnumerable<ItemApoioViewModel>>(itens);

		}

		public IEnumerable<ItemApoioViewModel> BuscarItemPorApoio(Guid apoioId)
		{
			return mapper.Map<IEnumerable<ItemApoioViewModel>>(itemApoioService.BuscarItemPorApoio(apoioId));
		}

		public IEnumerable<ItemApoioViewModel> BuscarTodos()
		{
			return mapper.Map<IEnumerable<ItemApoioViewModel>>(itemApoioService.BuscarTodos());
		}

		public IEnumerable<ItemApoioViewModel> GetAll()
		{
			return mapper.Map<IEnumerable<ItemApoioViewModel>>(itemApoioService.GetAll());
		}
	}
}
