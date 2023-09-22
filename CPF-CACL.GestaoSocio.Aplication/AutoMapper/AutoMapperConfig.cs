using AutoMapper;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Aplication.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region ViewModelToDomain

            CreateMap<PessoaViewModel, Pessoa>();

            #endregion

            #region DomainToViewModel

            CreateMap<Pessoa, PessoaViewModel>();

            #endregion
        }
    }
}
