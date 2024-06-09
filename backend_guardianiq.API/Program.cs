using backend_guardianiq.API.ActiveService.Domain.Repositories;
using backend_guardianiq.API.ActiveService.Infrastructure.Persistence.EFC.Repositories;
using backend_guardianiq.API.Shared.Domain.Repositories;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend_guardianiq.API.ActiveService.Application.Internal;
using backend_guardianiq.API.ActiveService.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
   options =>
   {
       if (connectionString != null)
       {
           if (builder.Environment.IsDevelopment())
           {
               options.UseMySQL(connectionString)
                   .LogTo(Console.WriteLine, LogLevel.Information)
                   .EnableSensitiveDataLogging()
                   .EnableDetailedErrors();
           }
           else if (builder.Environment.IsProduction())
           {
               options.UseMySQL(connectionString)
                   .LogTo(Console.WriteLine, LogLevel.Error)
                   .EnableDetailedErrors();
           }
       }
   });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
