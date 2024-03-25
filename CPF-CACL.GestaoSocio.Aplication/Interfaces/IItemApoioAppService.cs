using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
	public interface IItemApoioAppService
	{
		IEnumerable<ItemApoioViewModel> BuscarTodos();
		IEnumerable<ItemApoioViewModel> GetAll();

		public IEnumerable<ItemApoioViewModel> BuscarItemApoioPorSocio(Guid socioId);
		public IEnumerable<ItemApoioViewModel> BuscarItemPorApoio(Guid apoioId);
	}
}
