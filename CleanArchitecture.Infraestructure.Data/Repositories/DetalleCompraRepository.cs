using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CleanArchitecture.Infraestructure.Data.Repositories
{
    public class DetalleCompraRepository : RepositoryEF<DetalleCompra>, IDetalleCompraRepository
    {
        protected readonly string _connectionString;
        public DetalleCompraRepository(DbContext context, string connectionString) : base(context)
        {
            repositoryEF = new RepositoryEF<DetalleCompra>(context);
            _connectionString = connectionString;
        }
        public IRepositoryEF<DetalleCompra> repositoryEF { get; set; }

        public async Task<List<DetalleCompra>> GetAll()
        {
            return await repositoryEF.GetAll();
        }
        public async Task<DetalleCompra> GetById(int id)
        {
            return await repositoryEF.GetEntityByIdAsync(id);
        }
        public void Insert(DetalleCompra compra)
        {
            repositoryEF.Insert(compra);
        }
        public void Update(DetalleCompra compra)
        {
            repositoryEF.Update(compra);
        }
        public void Delete(int id)
        {
            DetalleCompra compra = repositoryEF.GetEntityById(id);
            repositoryEF.Delete(compra);
        }

        public async Task<List<DetalleComprasDto>> ObtenerDetalleCompra(int idCompra)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var parameters = new DynamicParameters();
            parameters.Add("IdCompra", idCompra);
            var resultado = await connection.QueryAsync<DetalleComprasDto>("sp_DetalleCompra", parameters, commandType: CommandType.StoredProcedure);
            List<DetalleComprasDto> listConsultaDeudas = resultado.Cast<DetalleComprasDto>().ToList();
            await connection.CloseAsync();
            return listConsultaDeudas;

        }
    }
}
