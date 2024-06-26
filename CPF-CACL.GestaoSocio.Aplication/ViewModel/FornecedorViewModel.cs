﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class FornecedorViewModel
    {

        [Key]
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public string? NIF { get; set; }
        public string? Endereco { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }

        public Guid BairroId { get; set; }
        public List<ItemDropDown>? Bairro { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } = "true";
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
