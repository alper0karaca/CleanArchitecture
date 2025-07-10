using CleanArchitecture.Application.Abtractions;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Email;
using CleanArchitecture.Persistance;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.WebApi.Middleware;
using CleanArchitecture.WebApi.OptionsSetup;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddTransient<ExceptionMiddleware>();

//Automapper
builder.Services.AddAutoMapper(typeof
    (CleanArchitecture.Persistance.AssemblyReference).Assembly);

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString));

// Mail configs
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IMailService, MailService>();

// services.AddScoped<AppDbContext>();
// generic
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// jwt configs
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

//identity 
builder.Services.AddIdentity<AppUser, AppUserRole>(options =>
    {
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
    })
    .AddEntityFrameworkStores<AppDbContext>();

// uygulamanın başka bir katmanda conntrollerların devam edeceğini bildiriyoruz.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

// CQRS için
builder.Services.AddMediatR(conf => 
    conf.RegisterServicesFromAssembly(
        typeof(CleanArchitecture.Application.AssemblyReference).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(
    typeof(CleanArchitecture.Application.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareExtensions();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
