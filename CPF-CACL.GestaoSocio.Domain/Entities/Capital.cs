namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Capital : BaseEntity
    {
        public Guid BeneficioId { get; set; }
        public virtual Beneficio Beneficio { get; set; }
        public Guid CategoriaSocioId { get; set; }
        public virtual CategoriaSocio CategoriaSocio { get; set; }
        public double Valor { get; set; }
    }
}
