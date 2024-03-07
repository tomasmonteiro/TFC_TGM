using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IMapper mapper;
        private readonly IFornecedorService fornecedorService;

        public FornecedorAppService(IFornecedorService fornecedorService, IMapper mapper)
        {
            this.mapper = mapper;
            this.fornecedorService = fornecedorService;
        }

        public void Add(FornecedorViewModel fornecedor)
        {
            fornecedorService.Add(mapper.Map<Fornecedor>(fornecedor));
        }

        public FornecedorViewModel BuscarPorCodigo(string codigo)
        {
            return mapper.Map<FornecedorViewModel>(fornecedorService.BuscarPorCod(codigo));
        }

        public FornecedorViewModel BuscarPorNif(string nif)
        {
            return mapper.Map<FornecedorViewModel>(fornecedorService.BuscarPorNif(nif));
        }

        public FornecedorViewModel BuscarPorNome(string nome)
        {
            return mapper.Map<FornecedorViewModel>(fornecedorService.BuscarPorNome(nome));
        }

        public IEnumerable<FornecedorViewModel> BuscarTodos()
        {
            return mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedorService.BuscarTodos());
        }
        public IEnumerable<FornecedorViewModel> GetAll()
        {
            return mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedorService.GetAll());
        }

        public void Inativar(Guid id)
        {
            fornecedorService.Eliminar(id);
        }
        public void Eliminar(FornecedorViewModel fornecedor)
        {
            fornecedorService.Remove(mapper.Map<Fornecedor>(fornecedor));
        }

        public FornecedorViewModel GetById(Guid id)
        {
            return mapper.Map<FornecedorViewModel>(fornecedorService.GetById(id));
        }

        public void Atualizar(FornecedorViewModel fornecedor)
        {
            fornecedorService.Update(mapper.Map<Fornecedor>(fornecedor));
        }
    }
}
