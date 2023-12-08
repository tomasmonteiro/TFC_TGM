using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Models.Entities
{
    public class PedidoApoio : BaseEntity
    {
        public string Descricao { get; set; }
        public EEstadoPedido EstadoPedido { get; set; }
        public int SocioId { get; set; }
        public virtual Socio Socio { get; set; }

    }
}
