﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Relacao : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<Dependente> Dependentes { get; set; }
    }
}
