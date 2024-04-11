using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Emolumento : BaseEntity
    {
        //Emolumento: refere-se a Joia, Quota, Multa e Outros emolumentos referente ao Sócio
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public EEstadoItem Estado { get; set; }
        public DateTime? DataVencimento { get; set; }
        public Guid TipoItemId { get; set; }
        public virtual TipoEmolumento TipoItem { get; set; }

        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public Guid PeriodoId { get; set; }
        public virtual Periodo Periodo { get; set; }

        public ICollection<PagamentoEmolumento> ItemPagamnetos { get; set; }
    }
}
