﻿namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }

        public int PerfilUsuarioId { get; set; }
        public virtual PerfilUsuario PerfilUsuario { get; set; }
        public ICollection<Apoio> Apoios { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
    }
}