﻿using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Despesa : BaseEntity
    {
        public double Valor { get; set; }
        public EEstadoDespesa EstadoDespesa { get; set; }
        public Guid ApoioId { get; set; }
        public virtual Apoio Apoio { get; set; }
        public Guid FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }


    }
}
