using CustomerSupplier.CrossCutting.Identity;
using CustomerSupplier.CrossCutting.Identity.Data;
using CustomerSupplier.Data;
using CustomerSupplier.Data.Repository;
using CustomerSupplier.Domain.Repository;
using CustomerSupplier.Domain.Sesrvices;
using CustomerSupplier.WebApi.Configurations;
using CustomerSupplier.WebApi.Configurations.Auth;
using CustomerSupplier.WebApi.Configurations.DependenceInjection;
using CustomerSupplier.WebApi.Dto;
using CustomerSupplier.WebApi.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddAuthorizationConfiguration(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureValidations();
builder.Services.ConfigureDomainServices();
builder.Services.ConfigureRepositories();

#region Migrations

builder.Services.ApplayDatabaseMigrations();

#endregion

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
