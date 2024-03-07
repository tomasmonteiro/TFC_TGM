using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class BairroAppService : IBairroAppService
    {
        private readonly IMapper mapper;
        private readonly IBairroService bairroService;
        //
        public BairroAppService(IMapper mapper, IBairroService bairroService)
        {
            this.mapper = mapper;
            this.bairroService = bairroService;
        }

        public void Adicionar(BairroViewModel bairroViewModel)
        {
            bairroService.Add(mapper.Map<Bairro>(bairroViewModel));
        }

        public IEnumerable<BairroViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<BairroViewModel>>(bairroService.BuscarTodos());  
        }
        public void Atualizar(BairroViewModel bairroViewModel)
        {
            bairroService.Update(mapper.Map<Bairro>(bairroViewModel));
        }
        public void Eliminar(Guid id)
        {
            bairroService.Eliminar(id);
        }
    }
}
