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
    public class ApoioService : ServiceBase, IApoioService
    {
        private readonly IApoioRepository _apoioRepository;
        private readonly IItemApoioRepository _itemApoioRepository;
        private readonly IDespesaRepository _despesaRepository;
        public ApoioService(IApoioRepository apoioRepository, IItemApoioRepository itemApoioRepository, IDespesaRepository despesaRepository, INotificador notificador) : base(notificador)
        {
            _apoioRepository = apoioRepository;
            _itemApoioRepository = itemApoioRepository;
            _despesaRepository = despesaRepository;
        }


        public IEnumerable<Apoio> BuscarApoioCocluido()
        {
            return _apoioRepository.BuscarApoioConcluido();
        }

        public IEnumerable<Apoio> BuscarApoioPendente()
        {
            return _apoioRepository.BuscarApoioPendente();
        }

        public void Add(Apoio apoio)
        {
            apoio.DataCriacao = DateTime.Now;
            _apoioRepository.Add(apoio);
        }
        public IEnumerable<Apoio> BuscarTodos()
        {
            return _apoioRepository.BuscarTodos();
        }
		public IEnumerable<Apoio> BuscarApoioPorSocio(Guid socioId)
		{
			return _apoioRepository.BuscarApoioPorSocio(socioId);
		}
		public void Eliminar(Guid id)
        {
            var apoio = _apoioRepository.GetById(id);
            if (apoio == null)
            {
                Notificar("O Apoio que pretende inativar não existe.");
                return;
            }
            apoio.Status = false;
            apoio.DataAtualizacao = DateTime.Now;
            _apoioRepository.Update(apoio);
        }

        public IEnumerable<Apoio> GetAll()
        {
            return _apoioRepository.GetAll();
        }

        public Apoio GetById(Guid id)
        {
            return _apoioRepository.GetById(id);
        }

        public void Remove(Apoio apoio)
        {
            var novoApoio = _apoioRepository.GetById(apoio.Id);
            if (novoApoio == null)
            {
                Notificar("O Apoio que pretende eliminar não existe.");
                return;
            }
            _apoioRepository.Remove(apoio);
        }

        public void Update(Apoio apoio)
        {
            apoio.DataAtualizacao = DateTime.Now;
            _apoioRepository.Update(apoio);
        }
        public void Dispose()
        {
            _apoioRepository.Dispose();
        }

        public void AdicionarApoio(List<DadosApoio> dadosApoio)
        {
            var apoio = new Apoio();
            apoio.DataApoio = dadosApoio[0].DataApoio;
            apoio.Descricao = dadosApoio[0].Descricao;
            apoio.Valor = dadosApoio.Sum(x => x.Valor);
            apoio.UsuarioId = dadosApoio[0].UsuarioId;
            apoio.EstadoApoio = Enums.EEstadoApoio.Concluido;
            apoio.SocioId = dadosApoio[0].SocioId;
            apoio.DataCriacao = DateTime.Now;
            apoio.Status = true;

            _apoioRepository.Add(apoio);

            if (apoio.Id == Guid.Empty)
            {
                Notificar("Não foi possível concluir a operação.");
                return;
            }


            foreach (var item in dadosApoio)
            {
                var itemApoio = new ItemApoio();

                itemApoio.DataCriacao = DateTime.Now;
                itemApoio.Status = true;
                itemApoio.ApoioId = apoio.Id;
                itemApoio.BeneficioId = item.BeneficioId;
                itemApoio.ForneceorId = item.FornecedorId;
                itemApoio.Valor = item.Valor * item.Quantidade;
                itemApoio.Quantidade = item.Quantidade;

                _itemApoioRepository.Add(itemApoio);
                var despesa = new Despesa();
                despesa.DataCriacao = DateTime.Now;
                despesa.Status = true;
                despesa.Valor = itemApoio.Valor;
                despesa.ApoioId = itemApoio.ApoioId;
                despesa.FornecedorId = itemApoio.ForneceorId;
                despesa.EstadoDespesa = Enums.EEstadoDespesa.NaoPago;
                _despesaRepository.Add(despesa);
            }


        }
    }
}
