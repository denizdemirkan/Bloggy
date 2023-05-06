using Bloggy.Core.Repositories;
using Bloggy.Core.Services;
using Bloggy.Core.UnitOfWorks;
using Bloggy.Repository.DbContexts;
using Bloggy.Repository.Repositories;
using Bloggy.Repository.UnitOfWorks;
using Bloggy.Service.Mappings;
using Bloggy.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Unit of Work Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Repository Layer Dependency Injection
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));

// Service Layer Dependency Injection
builder.Services.AddScoped(typeof(IBlogService), typeof(BlogService));

//AutoMapper ==> install AutoMapper.Extensions.Microsoft.DependencyInjection package
builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<MsSqlDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDbContext"), option =>
    {
        // Get me Assembly (App) that has MsSqlDbContext in it.
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(MsSqlDbContext)).GetName().Name);
    });
});

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