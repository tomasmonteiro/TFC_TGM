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
            CreateMap<SocioViewModel, Socio>().ReverseMap();
            CreateMap<CategoriaSocioViewModel, CategoriaSocio>().ReverseMap();
            CreateMap<OrganismoViewModel, Organismo>().ReverseMap();
            CreateMap<DependenteViewModel, Dependente>().ReverseMap();
            CreateMap<RelacaoViewModel, Relacao>().ReverseMap();

            CreateMap<ItemViewModel, Item>().ReverseMap();
            CreateMap<TipoItemViewModel, TipoItem>().ReverseMap();
            CreateMap<PagamentoViewModel, Pagamento>().ReverseMap();
            CreateMap<PeriodoViewModel, Periodo>().ReverseMap();
            CreateMap<ItemPagamentoViewModel, ItemPagamento>().ReverseMap();
            CreateMap<SaldoViewModel, Saldo>().ReverseMap();
            CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
            CreateMap<TipoBeneficioViewModel, TipoBeneficio>().ReverseMap();
            CreateMap<BeneficioViewModel, Beneficio>().ReverseMap();
            CreateMap<CapitalViewModel, Capital>().ReverseMap();
            CreateMap<ApoioViewModel, Apoio>().ReverseMap();
            CreateMap<DadosApoioViewModel, DadosApoio>().ReverseMap();

			CreateMap<ItemApoioViewModel, ItemApoio>().ReverseMap();

			CreateMap<DespesaViewModel, Despesa>().ReverseMap();

			#endregion

			#region DomainToViewModel



			CreateMap<TipoPagamento, TipoPagamentoViewModel>().ReverseMap().ForMember(c => c.Pagamentos, opt => opt.Ignore());
            CreateMap<Municipio, MunicipioViewModel>().ReverseMap().ForMember(c => c.Bairros, opt => opt.Ignore());
            
            CreateMap<Bairro, BairroViewModel>()
                .ForMember(c => c.Municipio, opt => opt.Ignore())
                .ForMember(dest => dest.NomeMunicipio, opt => opt.MapFrom(src => src.Municipio.Nome));
            

            CreateMap<Socio, SocioViewModel>().ReverseMap()
                .ForMember(c => c.Organismo, opt => opt.Ignore())
                .ForMember(c => c.CategoriaSocio, opt => opt.Ignore());

            CreateMap<CategoriaSocio, CategoriaSocioViewModel>().ReverseMap()
                .ForMember(c => c.Socios, opt => opt.Ignore());

            CreateMap<Organismo, OrganismoViewModel>().ReverseMap()
                .ForMember(c => c.Socios, opt => opt.Ignore());

            CreateMap<Dependente, DependenteViewModel>()
                .ForMember(c => c.Relacao, opt => opt.Ignore())
                .ForMember(dest => dest.NomeSocio, opt => opt.MapFrom(src => src.Socio.Nome))
                .ForMember(dest => dest.NomeRelacao, opt => opt.MapFrom(src => src.Relacao.Nome));

            CreateMap<Relacao, RelacaoViewModel>().ReverseMap()
                .ForMember(c => c.Dependentes, opt => opt.Ignore());

            CreateMap<Item, ItemViewModel>()
                .ForMember(dest => dest.NomeTipoItem, opt => opt.MapFrom(src => src.TipoItem.Descricao))
                .ForMember(dest => dest.NomeSocio, opt => opt.MapFrom(src => src.Socio.Nome))
                .ForMember(dest => dest.CodPeriodo, opt => opt.MapFrom(src => src.Periodo.Cod));

            CreateMap<TipoItem, TipoItemViewModel>().ReverseMap()
                .ForMember(c => c.Items, opt => opt.Ignore());

            CreateMap<Pagamento, PagamentoViewModel>()
                .ForMember(dest => dest.NomeSocio, opt => opt.MapFrom(src => src.Socio.Nome))
                .ForMember(dest => dest.NomeTipoPagamento, opt => opt.MapFrom(src => src.TipoPagamento.Nome));

            CreateMap<Periodo, PeriodoViewModel>().ReverseMap()
                .ForMember(c => c.Items, opt => opt.Ignore());


            CreateMap<ItemPagamento, ItemPagamentoViewModel>().ReverseMap()
                .ForMember(c => c.Pagamento, opt => opt.Ignore())
                .ForMember(c => c.Item, opt => opt.Ignore());


            CreateMap<Saldo, SaldoViewModel>()
                .ForMember(dest => dest.NomeSocio, opt => opt.MapFrom(src => src.Socios.Nome));


            CreateMap<Usuario, UsuarioViewModel>().ReverseMap()
                .ForMember(c => c.Apoios, opt => opt.Ignore())
                .ForMember(c => c.Pagamentos, opt => opt.Ignore());

            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap()
                    .ForMember(c => c.Bairros, opt => opt.Ignore()); 

            CreateMap<TipoBeneficio, TipoBeneficioViewModel>().ReverseMap()
                    .ForMember(c => c.Beneficios, opt => opt.Ignore());

            CreateMap<Beneficio, BeneficioViewModel>()
                .ForMember(c => c.TipoBeneficio, opt => opt.Ignore())
                .ForMember(dest => dest.NomeTipo, opt => opt.MapFrom(src => src.TipoBeneficio.Nome));

            CreateMap<Capital, CapitalViewModel>()
                .ForMember(c => c.Beneficio, opt => opt.Ignore())
                .ForMember(dest => dest.NomeBeneficio, opt => opt.MapFrom(src => src.Beneficio.Nome))
                .ForMember(c => c.Categoria, opt => opt.Ignore())
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.CategoriaSocio.Nome));


            CreateMap<Apoio, ApoioViewModel>()
                .ForMember(c => c.Socio, opt => opt.Ignore())
                .ForMember(dest => dest.NomeSocio, opt => opt.MapFrom(src => src.Socio.Nome));

            CreateMap<DadosApoio, DadosApoioViewModel>().ReverseMap();

			CreateMap<ItemApoio, ItemApoioViewModel>()
				.ForMember(c => c.Beneficio, opt => opt.Ignore())
				.ForMember(dest => dest.NomeBeneficio, opt => opt.MapFrom(src => src.Beneficio.Nome))
				.ForMember(c => c.Apoio, opt => opt.Ignore())
				.ForMember(dest => dest.DescricaoApoio, opt => opt.MapFrom(src => src.Apoio.Descricao))
				.ForMember(c => c.Fornecedor, opt => opt.Ignore())
				.ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome))
				.ForMember(dest => dest.DataApoio, opt => opt.MapFrom(src => src.Apoio.DataApoio));

			CreateMap<Despesa, DespesaViewModel>()
				.ForMember(c => c.Fornecedor, opt => opt.Ignore())
				.ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome))
				.ForMember(c => c.Apoio, opt => opt.Ignore())
				.ForMember(dest => dest.DescricaoApoio, opt => opt.MapFrom(src => src.Apoio.Descricao));


			#endregion
		}
	}
}
