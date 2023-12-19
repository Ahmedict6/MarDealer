using AutoMapper;
using Business.Common;
using Business.Implementation.Common;
using Business.Implementation.Product_Business;
using Business.Implementation.Shopping;
using Business.Interfaces.Common;
using Business.Interfaces.Product_Business;
using Business.Interfaces.Shopping;
using Entities;
using Entities.Models.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();


var st = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MARDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Entities")),
ServiceLifetime.Scoped);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//});

// register business
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductCategoryBusiness, ProductCategoryBusiness>();
builder.Services.AddTransient<IProductInventoryBusiness, ProductInventoryBusiness>();
builder.Services.AddTransient<ISubCategoryBusiness, SubCategoryBusiness>();
builder.Services.AddTransient<ISubOfSubCategoryBusiness, SubOfSubCategoryBusiness>();
builder.Services.AddTransient<IDocumentItemBusiness, DocumentItemBusiness>();
builder.Services.AddTransient<IProductBusiness, ProductBusiness>();
builder.Services.AddTransient<IOrderBusiness, OrderBusiness>();
builder.Services.AddTransient<IOrderItemBusiness, OrderItemBusiness>();
builder.Services.AddTransient<IOrderPaymentBusiness, OrderPaymentBusiness>();
builder.Services.AddTransient<ILookupDataBusiness, LookupDataBusiness>();
builder.Services.AddTransient<IProductBusiness, ProductBusiness>();
builder.Services.AddTransient<IUserBusiness, UserBusiness>();

// auto mapper config
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfig());
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
// auto mapper config end

//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });
//Jwt configuration ends here

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
