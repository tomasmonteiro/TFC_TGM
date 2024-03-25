using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class UsuarioSocio : BaseEntity
    {
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }
    }
}
