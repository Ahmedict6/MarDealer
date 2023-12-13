using Business.Implementation.Common;
using Business.Implementation.Product_Business;
using Business.Interfaces.Common;
using Business.Interfaces.Product_Business;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();


var st = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MARDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Entities")),
ServiceLifetime.Transient);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//});

// register business
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductCategoryBusiness, ProductCategoryBusiness>();
builder.Services.AddTransient<IProductInventoryBusiness, ProductInventoryBusiness>();
builder.Services.AddTransient<ISubCategoryBusiness, SubCategoryBusiness>();
builder.Services.AddTransient<ISubOfSubCategoryBusiness, SubOfSubCategoryBusiness>();
builder.Services.AddTransient<IDocumentItemBusiness, DocumentItemBusiness>();
builder.Services.AddTransient<IProductBusiness, ProductBusiness>();

var app = builder.Build();


app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
