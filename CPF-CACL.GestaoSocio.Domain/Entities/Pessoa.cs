using CPF_CACL.GestaoSocio.Domain.Enums;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string BI { get; set; }
        public EGenero Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public int ObterIdade()
        {
            return (DateTime.Now.Year - DataNascimento.Year);
        }
    }
}
