using CPF_CACL.GestaoSocio.Domain.Enums;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Pagamento : BaseEntity
    {
        public string Recibo { get; set; }
        public double Valor { get; set; }
        public EEstadoPagamento Estado { get; set; } = EEstadoPagamento.Disponivel;
        public DateTime DataPagamento { get; set; }
        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }

        public Guid TipoPagamentoId { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }

        public IEnumerable<PagamentoEmolumento> ItemPagamnetos { get; set; }
        public ICollection<Saldo> Saldo { get; set; }
    }
}
