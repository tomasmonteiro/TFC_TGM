using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Dependente : BaseEntity
    {
        public string Nome { get; set; }
        public string? BI { get; set; }
        public EGenero Genero { get; set; }
        public string? Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }

        public Guid RelacaoId { get; set; }
        public virtual Relacao Relacao { get; set; }


        public int CalcularIdade(DateTime dataNascimento)
        {
            return DateTime.Now.Year - dataNascimento.Year;
        }
    }
}
