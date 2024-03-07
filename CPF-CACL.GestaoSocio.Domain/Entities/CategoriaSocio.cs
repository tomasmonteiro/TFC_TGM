using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class CategoriaSocio : BaseEntity
    {
        public string Nome { get; set; }
        public double Quota { get; set; }

        public ICollection<Socio> Socios { get; set; }
        public ICollection<Capital> Capitais { get; set; }
    }
}
