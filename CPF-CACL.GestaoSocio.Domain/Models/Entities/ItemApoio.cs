namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class ItemApoio : BaseEntity
    {
        public double Valor { get; set; }
        public int Quantidade { get; set; }

        public Guid BeneficioId { get; set; }
        public virtual Beneficio Beneficio { get; set; }
        public Guid ApoioId { get; set; }
        public virtual Apoio Apoio { get; set; }
        public Guid ForneceorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
