using CPF_CACL.GestaoSocio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string? Email { get; set; }
        public EPerfilUsuario Perfil { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
