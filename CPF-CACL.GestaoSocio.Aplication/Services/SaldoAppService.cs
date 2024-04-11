using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class SaldoAppService : ISaldoAppService
    {
        private readonly IMapper mapper;
        private readonly ISaldoService saldoService;
        public SaldoAppService(ISaldoService saldoService, IMapper mapper)
        {
            this.mapper = mapper;
            this.saldoService = saldoService;
        }
        public void Adicionar(SaldoViewModel saldo)
        {
            saldoService.Add(mapper.Map<Saldo>(saldo));
        }
        public void Atualizar(SaldoViewModel saldo)
        {
            saldoService.Update(mapper.Map<Saldo>(saldo));
        }

        public IEnumerable<SaldoViewModel> BuscarDisponivel(Guid id)
        {
            return mapper.Map<IEnumerable<SaldoViewModel>>(saldoService.BuscarDisponivel(id));
        }

        public SaldoViewModel BuscarPorId(Guid id)
        {
            return mapper.Map<SaldoViewModel>(saldoService.GetById(id));
        }

        public SaldoViewModel BuscarPorSocio(Guid idSocio)
        {
            return mapper.Map<SaldoViewModel>(saldoService.BuscarPorSocio(idSocio));
        }

        public IEnumerable<SaldoViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<SaldoViewModel>>(saldoService.BuscarTodos());
        }
        public void Eliminar(Guid id)
        {
            saldoService.Eliminar(id);
        }
    }
}