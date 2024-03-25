using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface ISocioRepository : IRepositoryBase<Socio>
    {
        ICollection<Socio> BuscarPorNome(string nome);
        Socio BuscarPorCodigo(string cod);
		Socio BuscarPorSemTrack(Guid socioId);
		ICollection<Socio> BuscarPorGenero(string genero);
        IEnumerable<Socio> BuscarTodos();
        public string ConsultarUltimoCodigo(string tipoEntidade, int anoAtual);
        int ContarSocios();
    }
}
