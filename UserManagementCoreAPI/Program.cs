using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using System;
using UserManagement.EmailService.Models;
using UserManagement.EmailService.Services;
using UserManagement_IService;
using UserManagementCoreAPI.Extention;
using UserManagementCoreAPI.Models;
using UserManagementCoreAPI.Utilities;
using UserManagementDbContext;
using UserManagementInterface;
using UserManagementRepository;
using UserManagementService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


builder.RegisterDependency();
builder.RegisterEmailConfiguration();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add background job scheduler
builder.RegisterQuartzJobSchedular();

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
