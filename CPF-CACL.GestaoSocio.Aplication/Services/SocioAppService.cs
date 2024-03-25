using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class SocioAppService : ISocioAppService
    {
        private readonly IMapper mapper;
        private readonly ISocioService socioService;
        //
        public SocioAppService(IMapper mapper, ISocioService socioService)
        {
            this.mapper = mapper;
            this.socioService = socioService;
        }

        public Guid Adicionar(SocioViewModel socioViewModel)
        {
            var socio = mapper.Map<Socio>(socioViewModel);
            return socioService.Adicionar(socio);
        }

        public void Atualizar(SocioViewModel socio)
        {
            socioService.Update(mapper.Map<Socio>(socio));
        }

        public IEnumerable<SocioViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<SocioViewModel>>(socioService.BuscarTodos());
        }

        public SocioViewModel BuscarPorCod(string codigo)
        {
            return mapper.Map<SocioViewModel>(socioService.BuscarPorCod(codigo));
        }

        public SocioViewModel BuscarPorId(Guid id)
		{ 
            var socio = socioService.GetById(id);
            if (socio.CaminhoFoto == null)
            {
                socio.CaminhoFoto = "img/user.png";
            }
			return mapper.Map<SocioViewModel>(socio);
		}

		public SocioViewModel BuscarPorSemTrack(Guid socioId)
		{
			return mapper.Map<SocioViewModel>(socioService.BuscarPorSemTrack(socioId));
		}

		public void Eliminar(Guid id)
        {
            socioService.Eliminar(id);
        }
    }
}
