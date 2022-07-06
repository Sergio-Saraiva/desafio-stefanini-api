using System;
using DesafioStefanini.Application.Mappings;
using DesafioStefanini.Domain.Interfaces;
using DesafioStefanini.Infra.Data.Context;
using DesafioStefanini.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioStefanini.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddAutoMapper(typeof(MappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("DesafioStefanini.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
