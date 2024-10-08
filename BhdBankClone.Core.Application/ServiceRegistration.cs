﻿using BhdBankClone.Core.Application.Validators.Accounts;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BhdBankClone.Core.Application
{
  public static class ServiceRegistration 
  {
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration config)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

      return services;
    }
  }
}
