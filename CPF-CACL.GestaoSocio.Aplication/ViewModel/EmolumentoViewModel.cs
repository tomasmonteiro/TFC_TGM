using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class EmolumentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(2, ErrorMessage = "O Código do Item precisa ter o mínimo de {0} caracteres")]
        [MaxLength(10, ErrorMessage = "O Código do Item precisa ter o márixo de {0} caracteres")]
        public string Cod { get; set; }

        [MinLength(2, ErrorMessage = "A Descrição precisa ter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "A Descrição precisa ter no márixo {1} caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Insira o Valor do Item")]
        public double Valor { get; set; }
        public EEstadoItem Estado { get; set; } = EEstadoItem.NaoPago;

        [Required(ErrorMessage = "Preencha o campo Data de Vewncimento")]
        [DataType(DataType.Date)]
        [Display(Name = "DataVencimento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataVencimento { get; set; }

        public Guid TipoItemId { get; set; }
        public string NomeTipoItem { get; set; }
        public List<TipoEmolumento> TipoItens { get; set; }
        public Guid SocioId { get; set; }
        public string NomeSocio { get; set; }
        public List<Socio> Socios { get; set; }
        public Guid PeriodoId { get; set; }
        public string CodPeriodo { get; set; }
        public List<Periodo> Periodos { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } = "true";
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
