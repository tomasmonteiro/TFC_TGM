using CPF_CACL.GestaoSocio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class DadosApoioViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; } = 1;
        public string Descricao { get; set; }
        public DateTime DataApoio { get; set; }

        public Guid SocioId { get; set; }

        public Guid BeneficioId { get; set; }

        public Guid ApoioId { get; set; }

        public Guid FornecedorId { get; set; }
        public Guid UsuarioId { get; set; }

        public string Status { get; set; } = "true";
        public DateTime DataCriacao { get; set; }
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
