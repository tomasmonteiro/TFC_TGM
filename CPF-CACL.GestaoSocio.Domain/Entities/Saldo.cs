using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Saldo : BaseEntity
    {
        public string Recibo { get; set; }
        public double Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public EEstadoPagamento Estado { get; set; } = EEstadoPagamento.Disponivel;
        public Guid SocioId { get; set; }
        public virtual Socio Socios { get; set; }
        public Guid PagamentoId { get; set; }
        public virtual Pagamento Pagamentos { get; set; }
    }
}
