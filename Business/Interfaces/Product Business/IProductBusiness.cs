using Business.Coomon;
using DTOs.Product_DTOs;
using Entities.Models;
using Entities.Models.Product_Management;
using Repository.Interfaces;

namespace Business.Interfaces.Product_Business
{
    public interface IProductBusiness : IGenericRepository<Product>
    {
        List<ProductList> GetAllProducts(Descriptor descriptor);
        ProductDetails GetProductDetails(int id);
        // List<ProductDetails> GetProductDetails(int v);
    }
}
