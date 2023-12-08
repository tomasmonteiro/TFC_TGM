using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class Agregado : Pessoa
    {
        public string Nacionalidade { get; set; }
        public int SocioId { get; set; }
        public virtual Socio Socio { get; set; }

        public int RelacaoId { get; set; }
        public virtual Relacao Relacao { get; set; }

    }
}
