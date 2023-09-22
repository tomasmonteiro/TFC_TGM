namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public Nullable<DateTime> DataAtualizacao { get; set; }
        
    }
}
