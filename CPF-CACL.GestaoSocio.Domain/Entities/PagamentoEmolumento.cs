﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class PagamentoEmolumento : BaseEntity
    {
        public DateTime DataInsercao { get; set; }
        public Guid PagamentoId { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public Guid ItemId { get; set; }
        public virtual Emolumento Item { get; set; }

    }
}
