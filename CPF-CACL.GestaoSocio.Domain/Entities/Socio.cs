﻿using CPF_CACL.GestaoSocio.Domain.Enums;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Socio : Pessoa
    {
        public string Cod { get; set; }
        public EEstadoCivil EstadoCivil { get; set; }
        public string? Profissao { get; set; }
        public string? Habilitacoes { get; set; }
        public string Nacionalidade { get; set; }
        public string NomeDoPai { get; set; }
        public string NomeDaMae { get; set; }
        public string? LocalDeTrabalho { get; set; }
        public string? Funcao { get; set; }
        public string? Departamento { get; set; }
        public Guid OrganismoId { get; set; }
        public virtual Organismo Organismo { get; set; }
        public EEstadoSocio EstadoSocio { get; set; }

        public Guid CategoriaSocioId { get; set; }
        public virtual CategoriaSocio CategoriaSocio { get; set; }


        public ICollection<Apoio> Apoios { get; set; }
        public ICollection<Dependente> Dependentes { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
        public ICollection<PedidoApoio> PedidoApoios { get; set; }
        public ICollection<ProjectoSocio> ProjectoSocios { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Saldo> Saldo { get; set; }
        public ICollection<UsuarioSocio> UsuarioSocios { get; set; }


    }
}
