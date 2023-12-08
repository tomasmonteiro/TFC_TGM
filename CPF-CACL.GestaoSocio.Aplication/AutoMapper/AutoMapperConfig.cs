using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

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
            CreateMap<SocioViewModel, Socio>().ReverseMap();
            CreateMap<CategoriaSocioViewModel, CategoriaSocio>().ReverseMap();
            CreateMap<OrganismoViewModel, Organismo>().ReverseMap();

            #endregion

            #region DomainToViewModel

            CreateMap<TipoPagamento, TipoPagamentoViewModel>().ReverseMap().ForMember(c => c.Pagamentos, opt => opt.Ignore());
            CreateMap<Municipio, MunicipioViewModel>().ReverseMap().ForMember(c => c.Bairros, opt => opt.Ignore());
            CreateMap<Bairro, BairroViewModel>().ReverseMap().ForMember(c => c.Municipio, opt => opt.Ignore());
            

            CreateMap<Socio, SocioViewModel>().ReverseMap()
                .ForMember(c => c.Organismo, opt => opt.Ignore())
                .ForMember(c => c.CategoriaSocio, opt => opt.Ignore());

            CreateMap<CategoriaSocio, CategoriaSocioViewModel>().ReverseMap()
                .ForMember(c => c.Socios, opt => opt.Ignore());

            CreateMap<Organismo, OrganismoViewModel>().ReverseMap().ForMember(c => c.Socios, opt => opt.Ignore());

            #endregion
        }
    }
}
