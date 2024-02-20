using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class SaldoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(2, ErrorMessage = "O Código do Recibo precisa ter o mínimo de {0} caracteres")]
        [MaxLength(50, ErrorMessage = "O Código do Recibo precisa ter o márixo de {0} caracteres")]
        public string Recibo { get; set; }

        [Required(ErrorMessage = "Insira o Valor do Pagamento")]
        public double Valor { get; set; }

        public EEstadoPagamento Estado { get; set; } = EEstadoPagamento.Disponivel;

        [Required(ErrorMessage = "Preencha o campo Data de Pagamento")]
        [DataType(DataType.Date)]
        [Display(Name = "DataPagamento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPagamento { get; set; }

        public Guid PagamentoId { get; set; }
        public List<ItemDropDown>? Pagamento { get; set; }

        public Guid SocioId { get; set; }
        public string NomeSocio { get; set; }
        public List<Socio> Socios { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } = "true";
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
