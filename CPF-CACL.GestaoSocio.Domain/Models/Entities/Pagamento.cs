namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Pagamento : BaseEntity
    {

        public string Descricao { get; set; }
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public int TipoPagamentoId { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }
        public int SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
