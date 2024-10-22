using DataAccess.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System;
using System.Text;
using WebApi.Extensions;

namespace WebApi.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            /* Configuração criada apenas para o exemplo usando a API do próprio .net (ASP.NET Core Identity) para gerenciamento de usuário, senhas, tokens e etc
            ATENÇÃO
            =========================================================================
            Para os projetos do Smart, deve se usar o FCA Security ou Smart Security que já provê integrações com o AD da FCA e já retorna um token
            para autorização e autenticação do usuário
            =========================================================================
            Smart security > Autenticação no Globalsafe
            */

            var stringConnection = configuration.GetConnectionString("CONNECTION_STRING");

            services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(stringConnection));

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<MainContext>()
            //    .AddDefaultTokenProviders();

            /* Configuração comum em qualquer projeto
             * Na seção abaixo a parametrização de validação do token é realizada
             */

            //var tokenConfig = new TokenConfiguration();
            //new ConfigureFromConfigurationOptions<TokenConfiguration>(
            //    configuration.GetSection("TokenConfiguration"))
            //        .Configure(tokenConfig);

            //services.AddSingleton(tokenConfig);

            //var key = Encoding.ASCII.GetBytes(tokenConfig.Secret);

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudience = tokenConfig.Audience,
            //        ValidIssuer = tokenConfig.Issuer,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});

            return services;
        }
    }
}
