using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class TipoDeclaracaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tipo")]
        [MaxLength(25, ErrorMessage = "O Tipo precisa ter o márixo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "O Tipo precisa ter o mínimo de {0} caracteres")]
        public string Tipo { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> DataAtualizacao { get; set; }

    }
}
