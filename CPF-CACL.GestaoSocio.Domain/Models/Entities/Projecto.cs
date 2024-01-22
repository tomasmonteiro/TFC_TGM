using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Projecto : BaseEntity
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataLancamento { get; set; }
        public Guid TipoProjectoId { get; set; }
        public virtual TipoProjecto TipoProjecto { get; set; }

        public ICollection<ProjectoSocio> ProjectoSocios { get; set; }

    }
}
