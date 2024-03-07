using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class TipoItem : BaseEntity
    {
        public string Descricao { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
