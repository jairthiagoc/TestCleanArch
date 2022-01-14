﻿using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );
            //Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            
            //Services
            services.AddScoped<IClienteService, ClienteService>();

            services.AddAutoMapper(typeof(DomainDTOMappingProfile));

            return services;
        }
    }
}