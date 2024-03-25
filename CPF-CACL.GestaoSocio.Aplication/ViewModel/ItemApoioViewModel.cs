using CPF_CACL.GestaoSocio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class ItemApoioViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; } = 1;

        public Guid BeneficioId { get; set; }
        public string NomeBeneficio { get; set; }
        public List<Beneficio>? Beneficios { get; set; }
        public List<ItemDropDown>? Beneficio { get; set; }

        public Guid ApoioId { get; set; }
        public string DescricaoApoio { get; set; }
        public List<Apoio>? Apoios { get; set; }
        public List<ItemDropDown>? Apoio { get; set; }

        public Guid FornecedorId { get; set; }
        public string NomeFornecedor { get; set; }
        public List<Fornecedor>? Fornecedores { get; set; }
        public List<ItemDropDown>? Fornecedor { get; set; }

		public DateTime DataApoio { get; set; }

		public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> DataAtualizacao { get; set; }

    }
}
