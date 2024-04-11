using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class PagamentoEmolumentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataInsercao { get; set; } = DateTime.Now;
        public Guid PagamentoId { get; set; }
        public Guid ItemId { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
