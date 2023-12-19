using Business.Coomon;
using DTOs.Product_DTOs;
using Entities.Models;
using Entities.Models.Product_Management;
using Repository.Interfaces;

namespace Business.Interfaces.Product_Business
{
    public interface IProductBusiness : IGenericRepository<Product>
    {
        void AddProduct(ProductPayloadDTO product);
        List<AllCategoriesDTO> GetAllCategories();
        List<ProductListDTO> GetAllProducts(Descriptor descriptor);
        ProductDetailsDTO GetProductDetails(int id);
        void UpdateProduct(ProductPayloadDTO productData);
        void InsertProduct(ProductPayloadDTO productData);
    }
}
