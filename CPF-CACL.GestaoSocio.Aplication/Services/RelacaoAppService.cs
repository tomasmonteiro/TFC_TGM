using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class RelacaoAppService : IRelacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly IRelacaoService _relacaoService;
        private readonly IRelacaoRepository _relacaoRepository;
        //
        public RelacaoAppService(IMapper mapper, IRelacaoService relacaoService, IRelacaoRepository relacaoRepository)
        {
            _mapper = mapper;
            _relacaoService = relacaoService;
            _relacaoRepository = relacaoRepository;
        }

        public void Adicionar(RelacaoViewModel relacaoViewModel)
        {
            _relacaoService.Add(_mapper.Map<Relacao>(relacaoViewModel));
        }
        public IEnumerable<RelacaoViewModel> Buscar()
        {
            return _mapper.Map<IEnumerable<RelacaoViewModel>>(_relacaoService.BuscarTodos());
        }

        public RelacaoViewModel BuscarPorId(Guid id)
        {
            return _mapper.Map<RelacaoViewModel>(_relacaoService.GetById(id));
        }

        public void Atualizar(RelacaoViewModel relacaoViewModel)
        {
            _relacaoService.Update(_mapper.Map<Relacao>(relacaoViewModel));
        }

        public void Eliminar(Guid id)
        {
            _relacaoService.Eliminar(id);
        }
    }
}
