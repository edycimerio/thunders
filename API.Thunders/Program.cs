
using Domain.Thunders;
using Microsoft.EntityFrameworkCore;
using Repository.Thunders;
using FluentValidation.AspNetCore;
using API.Thunders.Validacao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices();
builder.Services.AddInfrastructure();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TarefaValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TarefaContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

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
