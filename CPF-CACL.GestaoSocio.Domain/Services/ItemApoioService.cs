using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
	public class ItemApoioService : ServiceBase, IItemApoioService
	{
		private readonly IItemApoioRepository _itemApoioRepository;
		private readonly IApoioRepository _apoioRepository;
		public ItemApoioService(IItemApoioRepository itemApoioRepository, IApoioRepository apoioRepository,  INotificador notificador) : base(notificador)
		{
			_itemApoioRepository = itemApoioRepository;
			_apoioRepository = apoioRepository;
		}

		public void Add(ItemApoio obj)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ItemApoio> BuscarItemPorApoio(Guid apoioId)
		{
			return _itemApoioRepository.BuscarItemPorApoio(apoioId);
		}

		public IEnumerable<ItemApoio> BuscarItemApoioPorSocio(Guid socioId)
		{
			return _itemApoioRepository.BuscarItemPorSocio(socioId);
		}
		public IEnumerable<ItemApoio> BuscarTodos()
		{
			return _itemApoioRepository.BuscarTodos();
		}

		public void Dispose()
		{
			_itemApoioRepository.Dispose();
		}

		public IEnumerable<ItemApoio> GetAll()
		{
			return _itemApoioRepository.GetAll();
		}

		public ItemApoio GetById(Guid id)
		{
			return _itemApoioRepository.GetById(id);
		}

		public void Remove(ItemApoio itemApoio)
		{
			var novoItemApoio = _itemApoioRepository.GetById(itemApoio.Id);
			if (novoItemApoio == null)
			{
				Notificar("O Item que pretende eliminar não existe.");
				return;
			}
			_itemApoioRepository.Remove(novoItemApoio);
		}
		public void Eliminar(Guid id)
		{
			var itemApoio = _itemApoioRepository.GetById(id);
			if (itemApoio == null)
			{
				Notificar("O Item que pretende inativar não existe.");
				return;
			}
			itemApoio.Status = false;
			Update(itemApoio);
		}

		public void Update(ItemApoio itemApoio)
		{
			itemApoio.DataAtualizacao = DateTime.Now;
			_itemApoioRepository.Update(itemApoio);
		}

	}
}
