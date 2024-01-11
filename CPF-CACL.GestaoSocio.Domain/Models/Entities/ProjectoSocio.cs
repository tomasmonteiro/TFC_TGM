using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class ProjectoSocio : BaseEntity
    {
        public string? Descricao { get; set; }
        public DateTime DataAtribuicao { get; set; }
        public int SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public int ProjectoId { get; set; }
        public virtual Projecto Projecto { get; set; }

    }
}
