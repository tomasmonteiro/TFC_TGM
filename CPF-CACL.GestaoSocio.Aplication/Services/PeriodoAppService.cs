using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class PeriodoAppService : IPeriodoAppService
    {
        private readonly IMapper mapper;
        private readonly IPeriodoService periodoService;
        public PeriodoAppService(IPeriodoService periodoService, IMapper mapper)
        {
            this.mapper = mapper;
            this.periodoService = periodoService;
        }
        //Cria um Período separado
        public void Adicionar(PeriodoViewModel periodo)
        {
            periodoService.Add(mapper.Map<Periodo>(periodo));
        }
        //Cria um Periodo e automaticamente criar as Quotas para os Sócios ativos
        public void AdicionarPeriodoEItem(PeriodoViewModel periodo)
        {
            periodoService.AdicionarPeriodoEItem(mapper.Map<Periodo>(periodo));
        }
        public void Atualizar(PeriodoViewModel periodo)
        {
            periodoService.Update(mapper.Map<Periodo>(periodo));
        }

        public PeriodoViewModel BuscarPorCod(string codigo)
        {
            return mapper.Map<PeriodoViewModel>(periodoService.BuscarPorCod(codigo));
        }
        public PeriodoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<PeriodoViewModel>(periodoService.GetById(id));
        }
        public IEnumerable<PeriodoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<PeriodoViewModel>>(periodoService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            periodoService.Eliminar(id);
        }
    }
}
