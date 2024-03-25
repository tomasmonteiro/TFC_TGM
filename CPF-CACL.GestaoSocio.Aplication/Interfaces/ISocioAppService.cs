using CPF_CACL.GestaoSocio.Aplication.ViewModel;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
	public interface ISocioAppService 
    {
        public Guid Adicionar(SocioViewModel socio);
        public IEnumerable<SocioViewModel> Buscar();
        public SocioViewModel BuscarPorId(Guid id);
		SocioViewModel BuscarPorSemTrack(Guid socioId);
		public SocioViewModel BuscarPorCod(string codigo);
        public void Atualizar(SocioViewModel socio);
        public void Eliminar(Guid id);
    }
}
