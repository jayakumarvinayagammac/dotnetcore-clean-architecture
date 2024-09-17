using System.Reflection;
using AutoMapper;
using ClassicModelApi;
using ClassicModelApplication.DataTransferObjectMapping;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Handlers;
using ClassicModelApplication.Queries;
using ClassicModelDomain.InfrastructureRepositories;
using ClassicModelInfrastructure.Contexts;
using ClassicModelInfrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

string mySQLConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ClassicModelsContext>(options =>
{
    options.UseMySql(mySQLConnection, ServerVersion.AutoDetect(mySQLConnection));
});



builder.Services
    .AddAndConfigureOrderService()      // Order services
    .AddAndConfigureCustomerService()   // Customer services
    .AddAndConfigureOfficeService();    // Office services

var mappingConfiguration = new MapperConfiguration( x=> {
    x.AddProfile( new Mapping());
});

IMapper mapper= mappingConfiguration.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);

builder.Services.AddControllers();
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
