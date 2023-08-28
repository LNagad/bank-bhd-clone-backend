using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain.settings;
using BhdBankClone.Infrastructure.Identity.Contexts;
using BhdBankClone.Infrastructure.Identity.Entities;
using BhdBankClone.Infrastructure.Identity.Interfaces;
using BhdBankClone.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;


namespace BhdBankClone.Infrastructure.Identity
{
  //Extension method - decorator
  public static class ServiceRegistration
  {
    public static IServiceCollection AddIdentityInfrastructureForApi(this IServiceCollection services, IConfiguration config)
    {
      #region Contexts

      AddContextConfiguration(services, config);

      #endregion

      #region Identity & JWT

      services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityContext>()
        .AddDefaultTokenProviders();

      services.Configure<JWTSettings>(config.GetSection("Authentication"));

      services.AddAuthentication(opt =>
      {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(opt =>
      {
        opt.RequireHttpsMetadata = true; // false in development
        opt.SaveToken = false;
        opt.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidateIssuerSigningKey = true,
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true, //si es valido
          ClockSkew = System.TimeSpan.Zero, // si ya expiro, no hay tiempo de gracia
          ValidIssuer = config["Authentication:Issuer"],
          ValidAudience = config["Authentication:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["Authentication:SecretKey"]))
        };

        opt.Events = new JwtBearerEvents()
        {
          OnAuthenticationFailed = c =>
          {
            c.NoResult();
            c.Response.StatusCode = 500;
            c.Response.ContentType = "text/plain";
            return c.Response.WriteAsync(c.Exception.ToString());
          },
          OnChallenge = c => // cuando no esta autenticado / token invalido
          {
            c.HandleResponse();
            c.Response.StatusCode = 401;
            c.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new Response<string>("You are not Authorized"));
            return c.Response.WriteAsync(result);
          },
          OnForbidden = c => // token valido pero no tiene permisos a la ruta
          {
            c.Response.StatusCode = 403;
            c.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new Response<string>("You are not Authorized to access this resource"));
            return c.Response.WriteAsync(result);
          }
        };
      });

      #endregion

      #region Services

      AddServicesConfiguration(services);

      #endregion

      return services;
    }

    #region Private methods

    private static void AddContextConfiguration(this IServiceCollection services, IConfiguration config)
    {
      if (config.GetValue<bool>("UseInMemoryDatabase"))
      {
        services.AddDbContext<IdentityContext>(opt => opt.UseInMemoryDatabase("DefaultConnection"));
      }
      else
      {
        services.AddDbContext<IdentityContext>(opt =>
        {
          //opt.EnableSensitiveDataLogging();
          opt.UseSqlServer(config.GetConnectionString("DefaultConnection"),
          m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
        });
      }
    }

    private static void AddServicesConfiguration(this IServiceCollection services)
    {
      services.AddTransient<IAccountService, AccountService>();
    }

    #endregion
  }
}
