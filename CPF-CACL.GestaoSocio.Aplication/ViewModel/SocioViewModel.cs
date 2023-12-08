using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class SocioViewModel
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(300, ErrorMessage = "O nome precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "O nome precisa ter no mínimo {1} caracteres")]
        public string? Nome { get; set; }


        [MaxLength(15, ErrorMessage = "O BI precisa ter no márixo {1} caracteres")]
        [MinLength(14, ErrorMessage = "O BI precisa ter no mínimo {1} caracteres")]
        public string? BI { get; set; }

        [Required(ErrorMessage = "Preencha o campo Genero")]
        [MaxLength(9, ErrorMessage = "O genero precisa ter no márixo {1} caracteres")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de Nascimento")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "01-01-1900", "{0:dd-MM-yyyy}", ErrorMessage ="A data de nascimento não pode ser uma data futura")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado Civil")]
        [MaxLength(20, ErrorMessage = "O estado civil precisa ter no márixo {1} caracteres")]
        public string EstadoCivil { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Habilitações Literárias")]
        //[MaxLength(20, ErrorMessage = "O campo habilitações precisa ter no márixo {1} caracteres")]
        public string Habilitacoes { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Nacionalidade")]
        [MaxLength(20, ErrorMessage = "A nacionalidade precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "A nacionalidade precisa ter no mínimo {1} caracteres")]
        public string Nacionalidade { get; set; }
         
        //[MaxLength(100, ErrorMessage = "A profissão precisa ter no márixo {1} caracteres")]
        //[MinLength(2, ErrorMessage = "A profissão precisa ter no mínimo  {1} caracteres")]
        public string Profissao { get; set; }

        [MaxLength(300, ErrorMessage = "O nome do pai precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "O nome do pai precisa ter no mínimo {1} caracteres")]
        public string? NomePai { get; set; }
         
        [MaxLength(300, ErrorMessage = "O nome da mãe precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "O nome da mãe precisa ter no mínimo {1} caracteres")]
        public string? NomeMae { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Endereço")]
        [MaxLength(300, ErrorMessage = "O endereço precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "O endereço precisa ter no mínimo {1} caracteres")]
        public string Endereco { get; set; }

        
        [DataType(DataType.PhoneNumber, ErrorMessage ="Formato incorreto")]
        [MaxLength(15, ErrorMessage = "O telefone precisa ter no márixo {1} caracteres")]
        [MinLength(9, ErrorMessage = "O telefone precisa ter no mínimo {1} caracteres")]
        public string Telefone { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage ="Formato de email incorreto")]
        [MaxLength(300, ErrorMessage = "O email precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "O email precisa ter no mínimo {1} caracteres")]
        public string? Email { get; set; }

        [MaxLength(200, ErrorMessage = "A função precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "A função precisa ter no mínimo {1} caracteres")]
        public string Funcao { get; set; }


        [MaxLength(200, ErrorMessage = "O departamento precisa ter no márixo {1} caracteres")]
        [MinLength(2, ErrorMessage = "O departamento precisa ter no mínimo {1} caracteres")]
        public string? Departamento { get; set; }


        [MaxLength(300, ErrorMessage = "O organismo precisa ter no márixo {1} caracteres")]
        public int OrganismoId { get; set; }
        public virtual Organismo Organismo { get; set; }

        [MaxLength(300, ErrorMessage = "O Local de Trabalho precisa ter o márixo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "O Local de Trabalho precisa ter o mínimo de {0} caracteres")]
        public string LocalDeTrabalho { get; set; }

        public EEstadoSocio EstadoSocio { get; set; } = EEstadoSocio.Ativo;
        
        [MaxLength(300, ErrorMessage = "A categoria precisa ter no márixo {1} caracteres")]
        public int CategoriaSocioId { get; set; }
        public List<ItemDropDown> CategoriaSocio { get; set; }


        [MaxLength(300, ErrorMessage = "O bairro precisa ter no márixo {1} caracteres")]
        public int BairroId { get; set; }
        public List<ItemDropDown> Bairro { get; set; }





        //[ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }

        //[ScaffoldColumn(false)]
        public string Status { get; set; }

        //[ScaffoldColumn(false)]
        public Nullable<DateTime> DataAtualizacao { get; set; }
    }
}
