using AutoMapper;
using Cinema.BLL.Interfaces;
using Cinema.BLL.Models;
using Cinema.BLL.Services;
using Cinema.DAL;
using Cinema.DAL.Entities;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Repositories;
using Cinema.Web.Configuratiojn;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DvdDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaDbConnection"));
    options.EnableSensitiveDataLogging();
}, ServiceLifetime.Scoped);

//void ConfigureServices(IServiceCollection services)
//{
//    //Some Code
//    services.AddDbContext<LibraryDbContext>();
//    //Some Code
//}

builder.Services.AddScoped<IDvdService, DvdService>();


builder.Services.AddScoped<IDvdRepository, DvdRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
    {
        IgnoreIsSpecifiedMembers = true,
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200", "https://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
