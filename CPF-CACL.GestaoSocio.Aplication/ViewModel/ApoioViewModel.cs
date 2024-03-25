using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class ApoioViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataApoio { get; set; }
        public double Valor { get; set; }
        public EEstadoApoio EstadoApoio { get; set; }
        public Guid SocioId { get; set; }
        public string NomeSocio { get; set; }
        public List<Socio> Socios { get; set; }
        public List<ItemDropDown> Socio { get; set; }

        public Guid UsuarioId { get; set; }

        public string Status { get; set; } = "true";
        public DateTime DataCriacao { get; set; }
        public Nullable<DateTime> DataAtualizacao { get; set; }

    }
}
