namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class ItemApoio : BaseEntity
    {
        public double Valor { get; set; }
        public int Quantidade { get; set; }

        public int BeneficioId { get; set; }
        public virtual Beneficio Beneficio { get; set; }
        public int ApoioId { get; set; }
        public virtual Apoio Apoio { get; set; }
        public int ForneceorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
