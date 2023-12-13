using Business.Coomon;
using Business.Interfaces;
using Business.Interfaces.Product_Business;
using DTOs.Product_DTOs;
using Entities;
using Entities.Models.Common;
using Entities.Models.Product_Management;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static Entities.Models.Common.DocumentItem;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        private readonly MARDBContext _context;
        private readonly IProductBusiness _productBussiness;

        public ProductsController(MARDBContext context,IProductBusiness productBusiness)
        {
            _context = context;
            this._productBussiness = productBusiness;
        }

     
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            var product = await Task.Run<ProductDetails>(() =>_productBussiness.GetProductDetails(id));
            if (product == null)
                return NotFound();
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Entities.Models.Product_Management.Product product)
        {
            _productBussiness.Insert(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Entities.Models.Product_Management.Product productData)
        {
            if (productData == null || productData.Id == 0)
                return BadRequest();

            var product = await _context.Products.FindAsync(productData.Id);
            if (product == null)
                return NotFound();
            product.ProductName = productData.ProductName;
            product.ProductDescritpion = productData.ProductDescritpion;
            product.ProductPrice = productData.ProductPrice;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();

        }


        [HttpPost("/GetProducts")]
        public Task<ApiResponse<List<ProductList>>> Getprodect(Descriptor descriptor)
        {

            ApiResponse<List<ProductList>> response = new ApiResponse<List<ProductList>>();



            IQueryable<Entities.Models.Product_Management.Product> query = _context.Products;


            query =  DescriptorProccer.QuryExcuter(descriptor, query);


            var Products = query.Include(q => q.ProductInventory).Include(q => q.ProductCategory).Include(q => q.SubCategory).Include(q => q.SubOfSubCategory).ToList();
            var productVms = new List<ProductList>();
            productVms = _productBussiness.GetAllProducts(descriptor);

            foreach (var Product in Products)
            {


                ProductList pvm = new ProductList
                {
                    Id = Product.Id,

                    ProductName = Product.ProductName,
                    ProductDescritpion = Product.ProductDescritpion,
                    ProductPrice = Product.ProductPrice,
                    UserNo = Product.UserNo,
                    ProductUnit = Product.ProductUnit,

                   // ProductImages = _context.DocumentItems.Where(q => q.RefereneceNumber == Product.Id && q.DocumentType == DocumentItemType.ProductImage).ToList()//), e => e.Id, d => d.RefreneceNumber, (Product, ProductImage) => new { Product.Id, Productinfo = Product, ProductImage 
                };

                productVms.Add(pvm);

            }
            response.Data = productVms;
            return Task.FromResult(response);// await _context.Products.Include(q => q.SubCategory).Include(q => q.ProductInventory).ToListAsync();// .Join(_context.DocumentItems, e => e.Id, d => d.RefreneceNumber, (Product, ProductImage) => new { Product.Id, Productinfo = Product, ProductImage }).ToListAsync();
        }



    }
}
