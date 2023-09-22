using CPF_CACL.GestaoSocio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.AutoMapper
{
    public class PessoaViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "O Nome precisa ter o márixo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "O Nome precisa ter o mínimo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo BI")]
        [MaxLength(14, ErrorMessage = "O Nº do BI precisa ter o márixo de {0} caracteres")]
        [MinLength(14, ErrorMessage = "O Nº do BI precisa ter o mínimo de {0} caracteres")]
        public string BI { get; set; }

        [Required(ErrorMessage = "Preencha o campo Gênero")]
        [MaxLength(9, ErrorMessage = "O Gênero precisa ter o márixo de {0} caracteres")]
        [MinLength(8, ErrorMessage = "O Gênero precisa ter o mínimo de {0} caracteres")]
        public EGenero Genero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefóne")]
        [MaxLength(12, ErrorMessage = "O nº de Telefóne precisa ter o márixo de {0} caracteres")]
        [MinLength(9, ErrorMessage = "O nº de Telefóne precisa ter o mínimo de {0} caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(150, ErrorMessage = "O Email precisa ter o márixo de {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um Email válido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Preencha o campo Nacionalidade")]
        [MaxLength(12, ErrorMessage = "A Nacionalidade precisa ter o márixo de {0} caracteres")]
        [MinLength(9, ErrorMessage = "A Nacionalidade precisa ter o mínimo de {0} caracteres")]
        public string Nacionalidade { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)]
        public bool Status { get; set; } = true;

   

    }
}
