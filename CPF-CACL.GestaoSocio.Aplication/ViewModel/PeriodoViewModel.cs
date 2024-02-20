using CPF_CACL.GestaoSocio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class PeriodoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(2, ErrorMessage = "O Código precisa ter o mínimo de {0} caracteres")]
        [MaxLength(10, ErrorMessage = "O Código precisa ter o márixo de {0} caracteres")]
        public string Cod { get; set; }
        public int Ano { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de Início do Período")]
        [DataType(DataType.Date)]
        [Display(Name = "DataInicio")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data Final do Período")]
        [DataType(DataType.Date)]
        [Display(Name = "DataInicio")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }

        public EEstadoPeriodo Estado { get; set; } = EEstadoPeriodo.Ativo;

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string Status { get; set; } = "true";
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
