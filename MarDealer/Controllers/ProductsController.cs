using Business;
using Entities;
using Entities.Models.Common;
using Entities.Models.Product_Management;
using MarDealer.NewFolder;
using Microsoft.AspNetCore.Mvc;
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

        public ProductsController(MARDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ApiResponse<List<ProductViewModel>>> Get()
        {


            ApiResponse<List<ProductViewModel>> response = new ApiResponse<List<ProductViewModel>>();



            var Products =  _context.Products.Include(q => q.SubCategory).Include(q => q.ProductInventory).ToList();
                var productVms = new List<ProductViewModel>();

            foreach (var Product in Products)
            {


                ProductViewModel pvm = new ProductViewModel
                {
                Id = Product.Id,

                ProductName = Product.ProductName,
                ProductDescritpion = Product.ProductDescritpion,
                ProductPrice = Product.ProductPrice,
                ProductCategoryNo = Product.ProductCategoryNo,
                ProductCategory = Product.ProductCategory,
                SubCategoryNo = Product.SubCategoryNo,
                SubCategory = Product.SubCategory,
                SubOfSubCategoryNo = Product.SubOfSubCategoryNo,
                SubOfSubCategory = Product.SubOfSubCategory,
                ProductInventory = Product.ProductInventory,
                ProductInventoryNo = Product.ProductInventoryNo,
                ProductDiscountNo = Product.ProductDiscountNo,
                ProductDiscount = Product.ProductDiscount,
                UserNo = Product.UserNo,
                ProductUnit = Product.ProductUnit,
                ProductCreatedDate = Product.ProductCreatedDate,
                ProductModifiedDate = Product.ProductModifiedDate,

                ProductImages = _context.DocumentItems.Where(q => q.RefreneceNumber == Product.Id && q.DocumentType == DocumentItemType.ProdectImage).ToList()//), e => e.Id, d => d.RefreneceNumber, (Product, ProductImage) => new { Product.Id, Productinfo = Product, ProductImage 
            };

                productVms.Add(pvm);

            }
            response.Data = productVms;
            return response;// await _context.Products.Include(q => q.SubCategory).Include(q => q.ProductInventory).ToListAsync();// .Join(_context.DocumentItems, e => e.Id, d => d.RefreneceNumber, (Product, ProductImage) => new { Product.Id, Productinfo = Product, ProductImage }).ToListAsync();
        }
        [HttpGet("GetprodectWithDocument/{id}")]
        public async Task<IEnumerable<dynamic>> GetprodectWithDocument(int id)
        {

            return await _context.Products.Join(_context.DocumentItems, e => e.Id, d => d.RefreneceNumber, (Product, ProductImage) =>  new { Product.Id,  Productinfo = Product, ProductImage }).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductViewModel product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductViewModel productData)
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
    }
}
