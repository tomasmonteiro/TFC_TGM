using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IFornecedorAppService
    {
        FornecedorViewModel BuscarPorNome(string nome);
        FornecedorViewModel BuscarPorCodigo(string codigo);
        FornecedorViewModel BuscarPorNif(string nif);
        IEnumerable<FornecedorViewModel> BuscarTodos();
        IEnumerable<FornecedorViewModel> GetAll();
        public void Add(FornecedorViewModel fornecedor);
        FornecedorViewModel GetById(Guid id);
        void Atualizar(FornecedorViewModel fornecedor);
        void Inativar(Guid id);
        void Eliminar(FornecedorViewModel fornecedor);

    }
}
