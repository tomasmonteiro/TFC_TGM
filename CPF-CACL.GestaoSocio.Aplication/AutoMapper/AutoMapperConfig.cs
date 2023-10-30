using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Aplication.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region ViewModelToDomain

            CreateMap<TipoPagamentoViewModel, TipoPagamento>().ReverseMap();
            CreateMap<MunicipioViewModel, Municipio>().ReverseMap();
            CreateMap<BairroViewModel, Bairro>().ReverseMap();

            #endregion

            #region DomainToViewModel


            CreateMap<TipoPagamento, TipoPagamentoViewModel>().ReverseMap().ForMember(c => c.Pagamentos, opt => opt.Ignore());
            CreateMap<Municipio, MunicipioViewModel>().ReverseMap().ForMember(c => c.Bairros, opt => opt.Ignore());
            CreateMap<Bairro, BairroViewModel>().ReverseMap().ForMember(c => c.Municipio, opt => opt.Ignore());

            #endregion
        }
    }
}
