using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class CompraServices: ICompraServices
    {
        protected ICompraRepository _compraRepository;
        public CompraServices(DbContext context)
        {
            _compraRepository = new CompraRepository(context);
        }
        public async Task<List<Compra>> GetAll()
        {
            return await _compraRepository.GetAll();
        }
        public async Task<Compra> GetById(int id)
        {
            return await _compraRepository.GetById(id);
        }
        public void  Insert(Compra compra)
        {
           _compraRepository.Insert(compra);
        }
        public void  Update(Compra compra)
        {
            _compraRepository.Update(compra);
        }

        public void UpdateFieldsSave(Compra compra)
        {
            _compraRepository.UpdateFieldsSave(compra);
        }
        public void  Delete(int id)
        {
             _compraRepository.Delete(id);
        }
    }
}
