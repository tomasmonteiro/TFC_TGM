﻿namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Fornecedor : BaseEntity
    {
        public string Nome { get; set; }
        public string? NIF { get; set; }
        public string? Endereco { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }

        public ICollection<ItemApoio> ItemApoios { get; set; }
    }
}
