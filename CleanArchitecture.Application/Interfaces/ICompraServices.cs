﻿using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICompraServices
    {
        Task<List<Compra>> GetAll();

        Task<Compra> GetById(int id);

       void  Insert(Compra compra);

       void  Update(Compra compra);

        void Delete(int id);
    }
}
