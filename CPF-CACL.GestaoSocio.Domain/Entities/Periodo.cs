using CPF_CACL.GestaoSocio.Domain.Enums;

namespace CPF_CACL.GestaoSocio.Domain.Entities
{
    public class Periodo : BaseEntity
    {
        public string Cod { get; set; }
        public int Ano { get; set; }
        public EEstadoPeriodo Estado { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime UltimoDiaUtil { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
