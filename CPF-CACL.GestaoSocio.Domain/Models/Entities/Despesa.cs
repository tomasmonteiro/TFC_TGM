using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Despesa : BaseEntity
    {
        public double Total { get; set; }
        public Guid ApoioId { get; set; }
        public virtual Apoio Apoio { get; set; }
        public EEstadoDespesa EstadoDespesa { get; set; }


    }
}
