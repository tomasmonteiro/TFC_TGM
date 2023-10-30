using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class TipoPagamentoService : ServiceBase<TipoPagamento>, ITipoPagamentoService
    {
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;
        public TipoPagamentoService(ITipoPagamentoRepository tipoPagamentoRepository) 
            : base(tipoPagamentoRepository)
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
        }

        public IEnumerable<TipoPagamento> BuscarTipos()
        {
            return _tipoPagamentoRepository.BuscarTodos();
        }
    }
}
