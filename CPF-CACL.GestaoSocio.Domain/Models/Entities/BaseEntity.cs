namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Status { get; set; } = true;
        public DateTime? DataAtualizacao { get; set; }

    }
}
