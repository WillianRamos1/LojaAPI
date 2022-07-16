using Loja.Application;
using Loja.Application.Contratos;
using Loja.Domain.Repositorios;
using Loja.Infra.Data.Context;
using Loja.Infra.Data.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.IoC
{
    public static class DependencyInjection
    {
            public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            {
            services.AddDbContext<DatabaseContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));});
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IPersonRepositorio, PersonRepository>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ICompraRepositorio, CompraRepositorio>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICompraService, CompraService>();
            return services;
            }
    }
}
