namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Status { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}
