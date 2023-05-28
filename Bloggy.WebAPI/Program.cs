using Bloggy.Core.Repositories;
using Bloggy.Core.Services;
using Bloggy.Core.UnitOfWorks;
using Bloggy.Repository.DbContexts;
using Bloggy.Repository.Repositories;
using Bloggy.Repository.UnitOfWorks;
using Bloggy.Service.Mappings;
using Bloggy.Service.Services;
using Bloggy.SharedLibrary.Extensions;
using Bloggy.SharedLibrary.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Modified with AddJsonOptions to avoiding Cycle Reference Error!
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// DbContext
builder.Services.AddDbContext<MsSqlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlDbContext"), sqlOptions =>
    {
        sqlOptions.MigrationsAssembly("Bloggy.Repository");
    });
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// DI Register of Generics (careful to multi type GenericService! It uses "," for each generic type)
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

// Unit of Work Dependency Injection
//builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Repository Layer Dependency Injection
//builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

// Service Layer Dependency Injection
//builder.Services.AddScoped(typeof(IBlogService), typeof(BlogService));
builder.Services.AddScoped<IBlogService, BlogService>();

//AutoMapper ==> install AutoMapper.Extensions.Microsoft.DependencyInjection package
builder.Services.AddAutoMapper(typeof(MapProfile));

// CORS Policy
builder.Services.AddCors(options =>
    {
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var tokenOptions = configuration.GetSection("TokenOption").Get<CustomTokenOption>();
// AddAuthentication() == 
builder.Services.AddCustomTokenAuth(tokenOptions);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS Policy
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
