namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class TipoPagamento : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }

    }
}
