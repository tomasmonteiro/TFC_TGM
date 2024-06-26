﻿using CPF_CACL.GestaoSocio.Domain.Enums;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Apoio : BaseEntity
    {
        public DateTime DataApoio { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public EEstadoApoio EstadoApoio { get; set; }
        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public ICollection<ItemApoio> ItemApoios { get; set; }
        public IEnumerable<Despesa> Despesas { get; set; }
    }
}
