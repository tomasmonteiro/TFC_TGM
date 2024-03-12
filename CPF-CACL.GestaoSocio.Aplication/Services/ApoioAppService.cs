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
    public class ApoioAppService : IApoioAppService
    {
        private readonly IMapper mapper;
        private readonly IApoioService apoioService;
        public ApoioAppService(IApoioService apoioService, IMapper mapper)
        {
            this.mapper = mapper;
            this.apoioService = apoioService;
        }
        public void Adicionar(ApoioViewModel apoioViewModel)
        {
            apoioService.Add(mapper.Map<Apoio>(apoioViewModel));
        }

        public void AdicionarApoio(List<DadosApoioViewModel> dadosApoioViewModel)
        {
            apoioService.AdicionarApoio(mapper.Map<List<DadosApoio>>(dadosApoioViewModel)); 
        }

        public void Atualizar(ApoioViewModel apoioViewModel)
        {
            apoioService.Update(mapper.Map<Apoio>(apoioViewModel));
        }

        public IEnumerable<ApoioViewModel> BuscarApoioConcluido()
        {
            return mapper.Map<IEnumerable<ApoioViewModel>>(apoioService.BuscarApoioCocluido());
        }

        public IEnumerable<ApoioViewModel> BuscarApoioPendente()
        {
            return mapper.Map<IEnumerable<ApoioViewModel>>(apoioService.BuscarApoioPendente());
        }

        public ApoioViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<ApoioViewModel>(apoioService.GetById(id));
        }

        public IEnumerable<ApoioViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<ApoioViewModel>>(apoioService.GetAll());
        }

        public IEnumerable<ApoioViewModel> BuscarTodosAtivos()
        {
            return mapper.Map<IEnumerable<ApoioViewModel>>(apoioService.BuscarTodos());
        }

        public void Eliminar(ApoioViewModel apoio)
        {
            apoioService.Remove(mapper.Map<Apoio>(apoio));
        }

        public void Inativar(Guid id)
        {
            apoioService.Eliminar(id);
        }
    }
}
