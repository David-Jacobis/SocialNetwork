using Arch.EntityFrameworkCore.UnitOfWork;
using Business.Interfaces;
using Business.Services;
using Business.ViewModels;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Models.Models;
using Resources;
using Serilog;
using WebApi.Extensions;

namespace WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Infrastructure
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            


            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //Services
            services.AddScoped<IUserService, UserService>();

            //Service With HttpClient


            //Resources

            services.AddTransient<CommonResource>();
            services.AddTransient<ErrorResource>();

            //Fluent Validation

            
            return services;
        }
    }
}
