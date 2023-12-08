using AutoMapper;
using CPF_CACL.GestaoSocio.Aplication.Interfaces;
using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Aplication.Services
{
    public class BairroAppService : IBairroAppService
    {
        private readonly IMapper mapper;
        private readonly IBairroService bairroService;
        private readonly IBairroRepository bairroRepository;
        //
        public BairroAppService(IMapper mapper, IBairroService bairroService, IBairroRepository bairroRepository)
        {
            this.mapper = mapper;
            this.bairroService = bairroService;
            this.bairroRepository = bairroRepository;
        }

        public void Adicionar(BairroViewModel bairroViewModel)
        {
            bairroService.Add(mapper.Map<Bairro>(bairroViewModel));
        }

        public IEnumerable<BairroViewModel> Buscar()
        {
            return mapper.Map<IEnumerable<BairroViewModel>>(bairroService.BuscarTodos());  
        }
        public void Atualizar(BairroViewModel bairroViewModel)
        {
            bairroService.Update(mapper.Map<Bairro>(bairroViewModel));
        }
        public void Eliminar(int id)
        {
            bairroService.Eliminar(id);
        }
    }
}
