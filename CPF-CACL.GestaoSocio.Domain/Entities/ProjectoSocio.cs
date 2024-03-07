using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class ProjectoSocio : BaseEntity
    {
        public string? Descricao { get; set; }
        public DateTime DataAtribuicao { get; set; }
        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public Guid ProjectoId { get; set; }
        public virtual Projecto Projecto { get; set; }

    }
}
