using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Organismo : BaseEntity
    {
        //Entidade que representa as Administrações Distritais e Direções
        public  string Nome { get; set; }

        public ICollection<Socio> Socios { get; set; }
    }
}
