﻿namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Fornecedor : BaseEntity
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string? NIF { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public string? Endereco { get; set; }
        public Guid BairroId { get; set; }
        public virtual Bairro Bairros { get; set; }
        public ICollection<ItemApoio> ItemApoios { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
    }
}
