﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class TipoApoio : BaseEntity
    {
        public string Tipo { get; set; }
        public IEnumerable<SolicitacaoApoio> SolicitacaoApoios{ get; set; }
    }
}
