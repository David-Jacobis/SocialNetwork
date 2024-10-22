using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using DataAccess.Context;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using WebApi.Common;
using WebApi.Configuration;
using WebApi.Extensions;
using FluentValidation.AspNetCore;
using Serilog;
using Microsoft.Extensions.Logging;
//using Business.ViewModels.OpenAi;
using Microsoft.AspNetCore.Hosting;
using Hangfire;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

//using Serilog.Sinks.;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.AddSwaggerConfig();


// DI Resource
builder.Services.AddLocalization(options => options.ResourcesPath = "");
builder.Services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo(CultureName.PT_BR),
                        new CultureInfo(CultureName.EN_US),
                        new CultureInfo(CultureName.ES_AR)
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: CultureName.EN_US, uiCulture: CultureName.EN_US);
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider { IndexOfCulture = 1, IndexofUICulture = 1 } };
                });

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
});



//builder.Services.AddHealthChecks()
//              .AddCheck(Environment.GetEnvironmentVariable("CONNECTION_STRING"), " - Main DB",
//              Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded);


var connectionString = builder.Configuration.GetConnectionString("CONNECTION_STRING");
var myEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information() // Configurar o nível mínimo de log
//    .WriteTo.Console()
//    .WriteTo.File($"{Environment.CurrentDirectory}/Logs/log-.txt", rollingInterval: RollingInterval.Day)
//    .WriteTo.MSSqlServer(connectionString, "Logs", autoCreateSqlTable: true) // Configurar o sink do SQL Server
//    .CreateLogger();



// Adicionar o logger do Serilog ao serviço de logging
//builder.Host.UseSerilog();
//builder.Services.AddLogging(loggingBuilder =>
//{
//    loggingBuilder.ClearProviders(); // Limpar outros provedores de logging
//    loggingBuilder.AddSerilog(); // Adicionar o logger do Serilog
//});


//Log.Logger.Information($"Environment.CurrentDirectory : {Environment.CurrentDirectory}");
//Log.Logger.Information($"myEnv - Environment.GetEnvironmentVariable(\"ASPNETCORE_ENVIRONMENT\") : {myEnv}");
//Log.Logger.Information($"connectionString - builder.Configuration.GetConnectionString(\"CONNECTION_STRING\"): {connectionString}");


builder.Services.AddDbContext<MainContext>(options =>
{
    options.UseOracle(connectionString);
}).AddUnitOfWork<MainContext>(); ;



IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

//builder.Services.AddSession();

var appSettings = new AppSettings();
new ConfigureFromConfigurationOptions<AppSettings>(
    Configuration.GetSection("AppSettings"))
        .Configure(appSettings);

builder.Services.AddSingleton(appSettings);
builder.Services.ResolveDependencies();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddIdentityConfig(Configuration);
builder.Services.AddHangFireConfig(Configuration);


builder.Services.AddMemoryCache(); // Adiciona o serviço de cache na memória


builder.Services.AddHttpClient("default", client =>
{
    client.Timeout = TimeSpan.FromSeconds(60); // Defina o tempo limite aqui (30 segundos, por exemplo)
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        // configuring cookie options
        options.Cookie.Name = "oidc";
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.IsEssential = true;
    })
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.NonceCookie.SecurePolicy = CookieSecurePolicy.Always;
        options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;
        // How middleware persists the user identity? (Cookie)
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.GetClaimsFromUserInfoEndpoint = true;
        // How Browser redirects user to authentication provider?
        // (direct get)
        options.AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet;

        // How response should be sent back from authentication provider?
        //(form_post)
        options.ResponseMode = OpenIdConnectResponseMode.FormPost;
        options.Authority = "https://idfed.mpsa.com"; // URL do servidor PingFederate
        options.ClientId = "your-client-id";
        options.ClientSecret = "your-client-secret";
        options.ResponseType = "code"; // Fluxo de Autorizao
        options.SaveTokens = true; // Salvar tokens para futuras requisies
        options.GetClaimsFromUserInfoEndpoint = true; // Buscar claims do userinfo
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://idfed.mpsa.com",
            ValidateAudience = true,
            ValidAudience = "your-client-id", // Ou o PRD code se aplicvel
            ValidateLifetime = true
        };

        options.Events = new OpenIdConnectEvents
        {
            OnRedirectToIdentityProviderForSignOut = context =>
            {
                context.Response.Redirect("/RedirectOnSignOut");
                context.HandleResponse();

                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                // Tratamento de falhas de autenticao
                context.Response.Redirect("/error?message=" + context.Exception.Message);
                context.HandleResponse();
                return Task.FromResult(0);
            }
        };
    });



//builder.WebHost.UseKestrel(options =>
//{
//    options.Limits.MaxConcurrentConnections = 100;
//    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(3);
//});


//builder.Services.AddApplicationInsightsTelemetry();

//builder.Services.AddFluentValidation(opt =>
//{
//    opt.RegisterValidatorsFromAssemblyContaining<Program>();
//});
var app = builder.Build();

app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseSwaggerConfig(appSettings);
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseHsts();
app.MapControllers();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
}); 

var localizedOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizedOptions.Value);





app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    //endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
    //{
    //    Predicate = _ => true,
    //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    //});
});




app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.UseCookiePolicy();



app.Run();










