using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PC12420021524100635.CORE.Core.Interfaces;
using PC12420021524100635.CORE.Infrastructure.Data;
using PC12420021524100635.CORE.Infrastructure.Repositories;
using PC12420021524100635.CORE.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services.AddDbContext<TallerMecanicoDbContext>(options =>
  options.UseSqlServer(cnx));

builder.Services.AddTransient<IOrdenServicioRepository, OrdenServicioRepository>();
builder.Services.AddTransient<IOrdenServicioService, OrdenServicioService>();

builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
  });
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
