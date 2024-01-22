using CPF_CACL.GestaoSocio.Domain.Enums;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string? BI { get; set; }
        public string? CaminhoFoto { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public Guid BairroId { get; set; }
        public virtual Bairro Bairros { get; set; }
        public string? Endereco { get; set; }

        public int CalcularIdade(DateTime dataNascimento)
        {
            return DateTime.Now.Year - dataNascimento.Year;
        }
    }
}
