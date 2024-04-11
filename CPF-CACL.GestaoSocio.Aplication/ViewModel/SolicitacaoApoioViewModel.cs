using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CPF_CACL.GestaoSocio.Aplication.ViewModel
{
    public class SolicitacaoApoioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Mensagem { get; set; }
        public IFormFile? Imagem { get; set; }
        public string? UrlAnexo { get; set; }
        public EEstadoSolicitacao EstadoSolicitacao { get; set; }

        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } = "true";
        public Nullable<DateTime> DataAtualizacao { get; set; }



        public Guid TipoApoioId { get; set; }
        public string NomeTipoApoio { get; set; }
        public List<TipoApoio> TipoApoios { get; set; }
        public List<ItemDropDown> TipoApoio { get; set; }

        public Guid SocioId { get; set; }
        public string NomeSocio { get; set; }
        public List<Socio> Socios { get; set; }

    }
}
