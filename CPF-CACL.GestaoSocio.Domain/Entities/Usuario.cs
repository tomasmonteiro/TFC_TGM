using CPF_CACL.GestaoSocio.Domain.Enums;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string? Email { get; set; }
        public EPerfilUsuario Perfil { get; set; }

        public ICollection<Apoio> Apoios { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
    }
}
