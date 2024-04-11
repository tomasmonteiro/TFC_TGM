using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class SolicitacaoDeclaracao : BaseEntity
    {
        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public Guid TipoDeclaracaoId { get; set; }
        public virtual TipoDeclaracao TipoDeclaracao { get; set; }
        public EEstadoSolicitacao EstadoSolicitacao { get; set; }
    }
}
