using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class SolicitacaoDeclaracaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } = "true";
        public Nullable<DateTime> DataAtualizacao { get; set; }


        public EEstadoSolicitacao EstadoSolicitacao { get; set; }

        public Guid TipoDeclaracaoId { get; set; }
        public string NomeTipoDeclaracao { get; set; }
        public List<TipoDeclaracao> TipoDeclaracoes { get; set; }
        public List<ItemDropDown> TipoDeclaracao { get; set; }

        public Guid SocioId { get; set; }
        public string NomeSocio { get; set; }
        public List<Socio> Socios { get; set; }

    }
}
