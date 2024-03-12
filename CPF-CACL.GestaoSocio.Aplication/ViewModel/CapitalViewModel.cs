using CPF_CACL.GestaoSocio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class CapitalViewModel
    {
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor")]
        public double Valor { get; set; }

        public Guid BeneficioId { get; set; }
        public string NomeBeneficio { get; set; }
        public List<Beneficio> Beneficios { get; set; }
        public List<ItemDropDown> Beneficio { get; set; }

        public Guid CategoriaSocioId { get; set; }
        public string NomeCategoria { get; set; }
        public List<CategoriaSocio> Categorias { get; set; }
        public List<ItemDropDown> Categoria { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> DataAtualizacao { get; set; }

    }
}
