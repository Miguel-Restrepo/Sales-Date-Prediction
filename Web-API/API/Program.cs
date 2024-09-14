using AutoMapper;
using Business.Dtos;
using Business.Mappers;
using Business.Services;
using Business.Services.Imp;
using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Imp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();

// AutoMapper
builder.Services.AddSingleton(provider =>
    new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<MappingProfile>();
    }).CreateMapper()
);

builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Shipper>, ShipperRepository>();
builder.Services.AddScoped<ICustomRepository, CustomRepository>();


builder.Services.AddScoped<IService<CustomerDto>, CustomerService>();
builder.Services.AddScoped<IService<EmployeeDto>, EmployeeService>();
builder.Services.AddScoped<IService<OrderDto>, OrderService>();
builder.Services.AddScoped<IService<ProductDto>, ProductService>();
builder.Services.AddScoped<IService<ShipperDto>, ShipperService>();
builder.Services.AddScoped<ICustomService, CustomService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
