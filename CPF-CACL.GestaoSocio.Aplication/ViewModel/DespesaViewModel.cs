using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
	public class DespesaViewModel
	{
		[Key]
		public Guid Id { get; set; }
		public double Valor { get; set; }
		public EEstadoDespesa EstadoDespesa { get; set; }
		public Guid ApoioId { get; set; }

		public string DescricaoApoio { get; set; }
		public List<Apoio> Apoios { get; set; }
		public List<ItemDropDown> Apoio { get; set; }

		public Guid FornecedorId { get; set; }
		public string NomeFornecedor { get; set; }
		public List<Fornecedor> Fornecedores { get; set; }
		public List<ItemDropDown> Fornecedor { get; set; }

		public string Status { get; set; } = "true";
		public DateTime DataCriacao { get; set; }
		public Nullable<DateTime> DataAtualizacao { get; set; }
	}
}
