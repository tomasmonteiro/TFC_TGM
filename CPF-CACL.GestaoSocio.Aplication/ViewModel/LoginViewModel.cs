using CPF_CACL.GestaoSocio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Digite o Login.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha.")]
        public string Senha { get; set; }
    }
}
