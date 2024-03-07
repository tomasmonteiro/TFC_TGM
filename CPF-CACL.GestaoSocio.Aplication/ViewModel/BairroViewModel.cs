using CPF_CACL.GestaoSocio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class BairroViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(50, ErrorMessage = "O Nome precisa ter o márixo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "O Nome precisa ter o mínimo de {0} caracteres")]
        public string Nome { get; set; }

        //[ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }

        //[ScaffoldColumn(false)]
        public string Status { get; set; } = "true";

        //[ScaffoldColumn(false)]
        public Nullable<DateTime> DataAtualizacao { get; set; }
        public Guid MunicipioId { get; set; }
        public string NomeMunicipio { get; set; }
        public List<Municipio> Municipios { get; set; }
        public List<ItemDropDown> Municipio { get; set; }

    }
}
