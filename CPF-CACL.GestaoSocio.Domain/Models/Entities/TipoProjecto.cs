using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class TipoProjecto : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<Projecto> Projectos { get; set; }
    }
}
