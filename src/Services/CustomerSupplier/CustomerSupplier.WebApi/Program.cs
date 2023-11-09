using CustomerSupplier.CrossCutting.Identity;
using CustomerSupplier.Data;
using CustomerSupplier.Data.Repository;
using CustomerSupplier.Domain.Repository;
using CustomerSupplier.Domain.Sesrvices;
using CustomerSupplier.WebApi.AuthConfiguration;
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

builder.Services.AddFluentValidation();
builder.Services.AddScoped<IValidator<CustomerSupplierDto>, CreateCustomerSupplierValidation>();
builder.Services.AddScoped<IValidator<CustomerSupplierAddressDto>, CreateCustomerSupplierAddressValifation>();
builder.Services.AddScoped<IValidator<CustomerSupplierContactDto>, CreateCustomerSupplierContactValidation>();

builder.Services.AddScoped<ICustomerSupplierService, CustomerSupplierService>();
builder.Services.AddScoped<IRepository, Repository>();

var serviceProvider = builder.Services.BuildServiceProvider();

var dbContext = serviceProvider.GetService<CustomerSupplierDbContext>();

dbContext.Database.Migrate();

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
