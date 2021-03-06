﻿using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Repository.interfaces
{
    public interface IEntradaEstoqueRepository : IGenericRepository<EntradaEstoque>
    {
        Task<ICollection<EntradaEstoque>> FindByData(int dia, int mes, int ano);
        Task<ICollection<EntradaEstoque>> FindByMaterialID(int id);
    }
}
