using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Agregado : Pessoa
    {   
        public string Nacionalidade { get; set; }
        public int SocioId { get; set; }
        public virtual Socio Socio { get; set; }

    }
}
