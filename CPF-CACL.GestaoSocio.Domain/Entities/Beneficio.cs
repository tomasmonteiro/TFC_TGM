namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Beneficio : BaseEntity
    {
        public string Nome { get; set; }
        public int TipoBeneficioId { get; set; }
        public virtual TipoBeneficio TipoBeneficio { get; set; }

        public ICollection<ItemApoio> ItemApoios { get; set; }
        public ICollection<Capital> Capitais { get; set; }
    }
}
