using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class SolicitacaoApoio : BaseEntity
    {
        public string Mensagem { get; set; }
        public string UrlAnexo { get; set; }
        public Guid SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public Guid TipoApoioId { get; set; }
        public virtual TipoApoio TipoApoio { get; set; }
        public EEstadoSolicitacao EstadoSolicitacao { get; set; }
    }
}
