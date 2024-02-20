using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class TipoItemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descricao")]
        [MinLength(2, ErrorMessage = "A Descricao precisa ter o mínimo de {0} caracteres")]
        [MaxLength(50, ErrorMessage = "A Descricao precisa ter o márixo de {0} caracteres")]
        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } = "true";
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
