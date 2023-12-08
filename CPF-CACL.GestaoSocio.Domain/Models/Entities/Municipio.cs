namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Municipio : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<Bairro> Bairros { get; set; }



    }
}
