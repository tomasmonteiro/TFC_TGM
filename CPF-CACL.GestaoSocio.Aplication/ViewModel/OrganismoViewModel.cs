using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class OrganismoViewModel
    {

        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "O Nome precisa ter o márixo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "O Nome precisa ter o mínimo de {0} caracteres")]
        public string Nome { get; set; }

        //[ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }

        //[ScaffoldColumn(false)]
        public string Status { get; set; }

        //[ScaffoldColumn(false)]
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
