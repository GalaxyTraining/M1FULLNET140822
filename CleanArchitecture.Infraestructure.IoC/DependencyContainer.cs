using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infraestructure.Data.Context;
using CleanArchitecture.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services,IConfiguration configuration)
        {
            //CleanArchitecture.Application
            //   services.AddScoped<IProductServices, ProductServices>();
            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infrastructure.Repositories
            //   services.AddScoped<IProductRepository, ProductRepository>();
         //   services.AddTransient<IUnitOfWork, UnitOfWork>();


            services.AddTransient<IUnitOfWork>(option => new UnitOfWork( new BDEmpresaContext(new DbContextOptionsBuilder<BDEmpresaContext>().UseSqlServer(configuration.GetConnectionString("ConnectionSqlServer")).Options), configuration.GetConnectionString("ConnectionSqlServer")));
        }
    }
}
