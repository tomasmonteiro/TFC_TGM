using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Notificacao : BaseEntity
    {
        public string Mensagem { get; set; }
        public bool Visualizada { get; set; }
    }
}
