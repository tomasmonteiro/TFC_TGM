using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
	public class ExtratoViewModel
	{
		public Guid ItemPagamentoId { get; set; }
		public DateTime DataRegisto { get; set; }

        public Guid PagamentoId { get; set; }
        public string ReciboPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        
        public Guid ItemId { get; set; }
        public string DescricaoItem { get; set; }
        public double ValorItem { get; set; }

    }
}
