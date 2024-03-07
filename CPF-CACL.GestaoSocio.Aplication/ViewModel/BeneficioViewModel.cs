using CPF_CACL.GestaoSocio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class BeneficioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(50, ErrorMessage = "O Nome precisa ter o márixo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "O Nome precisa ter o mínimo de {0} caracteres")]
        public string Nome { get; set; }
         
        public string Status { get; set; } = "true";
        public DateTime DataCriacao { get; set; }
        public Nullable<DateTime> DataAtualizacao { get; set; }
        public Guid TipoBeneficioId { get; set; }
        public string NomeTipo { get; set; }
        public List<TipoBeneficio> TipoBeneficios { get; set; }
        public List<ItemDropDown> TipoBeneficio { get; set; }

    }
}
