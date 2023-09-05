using BhdBankClone.Core.Application;
using BhdBankClone.Core.Domain;
using BhdBankClone.Infrastructure.Identity;
using BhdBankClone.Infrastructure.Identity.Entities;
using BhdBankClone.Infrastructure.Identity.Seeds;
using BhdBankClone.Infrastructure.Persistence;
using BhdBankCloneApi.Extensions;
using BhdBankCloneApi.Middlewares;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
  options.SuppressInferBindingSourcesForParameters = true;
  options.SuppressMapClientErrors = true;
}).AddJsonOptions(options =>
{
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
  //options.JsonSerializerOptions.MaxDepth = 1; // Establece el m�ximo nivel de profundidad permitido
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructureForApi(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);

var app = builder.Build();

// Configure identity seed scopes
await app.Services.AddIdentitySeed();

// Configure database migration scopes
//using (var scope = app.Services.CreateScope())
//{
//  try
//  {
//    ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
//    context.Database.Migrate();
//  }
//  catch (Exception ex)
//  {
//    Console.WriteLine(ex.Message);
//  }
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandleMiddleware>();
app.UseHttpsRedirection();
app.UseHsts();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
