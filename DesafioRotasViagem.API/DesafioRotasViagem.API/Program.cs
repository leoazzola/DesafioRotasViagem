using DesafioRotasViagem.Application;
using DesafioRotasViagem.Application.Interfaces;
using DesafioRotasViagem.Infra;
using DesafioRotasViagem.Infra.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IRotasViagemService, RotasViagemService>();
builder.Services.AddScoped<IRotasViagemRepository, RotasViagemRepository>();

builder.Services.AddDbContext<RotasViagemContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RotasViagemContext>();
    context.Database.Migrate();
    RotasViagemContext.SeedDatabase(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
