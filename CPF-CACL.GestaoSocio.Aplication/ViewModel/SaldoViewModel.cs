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
    public class SaldoViewModel
    {
        [Key]
        public Guid Id { get; set; }



        [Required(ErrorMessage = "Insira o Valor do Pagamento")]
        public double Valor { get; set; }

        public EEstadoPagamento Estado { get; set; } = EEstadoPagamento.Disponivel;

        public Guid SocioId { get; set; }
        public string NomeSocio { get; set; }
        public List<Socio> Socios { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } = "true";
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
