namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Pagamento : BaseEntity
    {
        public string Cod { get; set; } 
        public string Descricao { get; set; }
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public Guid TipoPagamentoId { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }
        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
