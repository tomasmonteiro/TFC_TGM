using CPF_CACL.GestaoSocio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class DependenteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(50, ErrorMessage = "O Nome precisa ter o márixo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "O Nome precisa ter o mínimo de {0} caracteres")]
        public string Nome { get; set; }

        [MaxLength(14, ErrorMessage = "O BI precisa ter no márixo {1} caracteres")]
        [MinLength(14, ErrorMessage = "O BI precisa ter no mínimo {1} caracteres")]
        public string? BI { get; set; }

        [Required(ErrorMessage = "Preencha o campo Genero")]
        [MaxLength(9, ErrorMessage = "O genero precisa ter no márixo {1} caracteres")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de Nascimento")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nacionalidade")]
        [MaxLength(20, ErrorMessage = "A nacionalidade precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "A nacionalidade precisa ter no mínimo {1} caracteres")]
        public string Nacionalidade { get; set; }

        public Guid RelacaoId { get; set; }
        public string NomeRelacao { get; set; }
        public List<Relacao> Relacoes { get; set; }
        public List<ItemDropDown> Relacao { get; set; }

        public Guid SocioId { get; set; }
        public string NomeSocio { get; set; }
        public List<Socio> Socios { get; set; }

        //[ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }

        //[ScaffoldColumn(false)]
        public string Status { get; set; } = "true";

        //[ScaffoldColumn(false)]
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
