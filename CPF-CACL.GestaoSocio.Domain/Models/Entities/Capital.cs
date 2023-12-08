using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Capital : BaseEntity
    {
        public int BeneficioId { get; set; }
        public virtual Beneficio Beneficio { get; set; }
        public int CategoriaSocioId { get; set; }
        public virtual CategoriaSocio CategoriaSocio { get; set; }
        public double Valor { get; set; }
    }
}
