using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Bairro : BaseEntity
    {
        public string Nome { get; set; }
        public Guid MunicipioId { get; set; }        
        public virtual Municipio Municipio { get; set; }

        public ICollection<Socio> Socios { get; set; }
    }
}
