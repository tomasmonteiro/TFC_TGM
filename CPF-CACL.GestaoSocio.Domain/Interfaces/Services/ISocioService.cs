﻿using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ISocioService : IServiceBase<Socio>
    {
        IEnumerable<Socio> BuscarPorNome(string nome);
        Socio BuscarPorCod(string codigo);
        public Guid Adicionar(Socio socio);
        public string GerarDodigoSocio();
    }
}
