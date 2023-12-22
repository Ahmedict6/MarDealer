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
        private readonly IProductBusiness _productBussiness;

        ApiResponse<ProductDetailsDTO> _ApiResponse = new ApiResponse<ProductDetailsDTO>();

        public ProductsController(IProductBusiness productBusiness)
        {
            this._productBussiness = productBusiness;
        }

        [HttpGet("GetAllCategories")]
        public async Task<ApiResponse<List<AllCategoriesDTO>>> GetAllCategories()
        {
            ApiResponse<List<AllCategoriesDTO>> _ApiResponse = new ApiResponse<List<AllCategoriesDTO>>();
            var product = await Task.Run<List<AllCategoriesDTO>>(() => _productBussiness.GetAllCategories());
            if (product == null)
            {
                _ApiResponse.Message = "Not Found";
                Response.StatusCode = 404;
                return _ApiResponse;
            }

            _ApiResponse = new ApiResponse<List<AllCategoriesDTO>>();
            _ApiResponse.Data = product;

            return _ApiResponse;

        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<ProductDetailsDTO>> Get(int id)
        {

            if (id < 1)
            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }


            var product = await Task.Run<ProductDetailsDTO>(() => _productBussiness.GetProductDetails(id));
            if (product == null)
            {
                _ApiResponse.Message = "Not Found";
                Response.StatusCode = 404;
                return _ApiResponse;


            }

            _ApiResponse = new ApiResponse<ProductDetailsDTO>();
            _ApiResponse.Data = product;

            return _ApiResponse;

        }

        [HttpPost]
        public async Task<ApiResponse<ProductDetailsDTO>> Post(ProductPayloadDTO product)
        {
            _productBussiness.AddProduct(product);

            _ApiResponse.Message = "added Successfully ";
            return _ApiResponse;
        }

        [HttpPut]
        public async Task<ApiResponse<ProductDetailsDTO>> Put(ProductPayloadDTO productData)
        {
            if (productData == null || productData.Id == 0)

            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }
            _productBussiness.UpdateProduct(productData);

            _ApiResponse.Message = "Updated Successfully ";

            return _ApiResponse;

        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse<ProductDetailsDTO>> Delete(int id = 0)
        {

            if (id < 1)
            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }

            _productBussiness.Delete(id);

            _ApiResponse.Message = "Deleted Successfully ";

            return _ApiResponse;

        }


        [HttpPost("api/GetProducts")]
        public Task<ApiResponse<List<ProductListDTO>>> Getprodect(Descriptor descriptor)
        {

            ApiResponse<List<ProductListDTO>> response = new ApiResponse<List<ProductListDTO>>();
            var productList = _productBussiness.GetAllProducts(descriptor);
            response.Data = productList;
            return Task.FromResult(response);
        }

    

    }
}
