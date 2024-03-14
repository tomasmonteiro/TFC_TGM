using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class DadosApoio : BaseEntity
    {
        public double Valor { get; set; }
        public int Quantidade { get; set; } = 1;
        public string Descricao { get; set; }
        public DateTime DataApoio { get; set; }

        public Guid SocioId { get; set; }

        public Guid BeneficioId { get; set; }

        public Guid ApoioId { get; set; }

        public Guid FornecedorId { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
