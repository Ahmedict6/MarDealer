using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Entities.Models.Product_Management;
using Repository;
using Entities;
using DTOs.Product_DTOs;
using Business.Coomon;
using Business.Interfaces.Product_Business;
using Entities.Models.Common;

namespace Business.Implementation.Product_Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<SubCategory> subCategoryRepo;
        private IGenericRepository<ProductInventory> productInventoryReop;
        private readonly IGenericRepository<DocumentItem> documentItemRepo;
        private IGenericRepository<ProductCategory> productCategoryRepo;
        private IGenericRepository<SubOfSubCategory> subOfSubCategoryRepo;

        public ProductBusiness(IUnitOfWork _unitOfWork,
            IGenericRepository<SubCategory> _subCategoryRepo,
            IGenericRepository<ProductCategory> _productCategoryRepo,
            IGenericRepository<SubOfSubCategory> _subOfSubCategoryRepo,
            IGenericRepository<DocumentItem> _documentItemRepo,
            IGenericRepository<ProductInventory> _productInventoryReop,
            IGenericRepository<Product> _productRepo, MARDBContext _context)
        {

            unitOfWork = _unitOfWork;
            subCategoryRepo = _subCategoryRepo;
            productCategoryRepo = _productCategoryRepo;
            subOfSubCategoryRepo = _subOfSubCategoryRepo;
            productInventoryReop = _productInventoryReop;
            documentItemRepo = _documentItemRepo;
            productRepo = _productRepo;
        }

        public void Delete(object id)
        {
            productRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(Func<Product, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<ProductList> GetAllProducts(Descriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public ProductDetails GetProductDetails(int id)
        {
            var product = unitOfWork.GetRepository<Product>().GetById(id);
            //var productCategory = unitOfWork.GetRepository<ProductCategory>().GetById(id);
            //var subCategory = unitOfWork.GetRepository<SubCategory>().GetById(id);
            //var subOfSubCategory = unitOfWork.GetRepository<SubOfSubCategory>().GetById(id);
            //var document = unitOfWork.GetRepository<DocumentItem>().GetById(id);
            //var productInventory = unitOfWork.GetRepository<ProductInventory>().GetById(product.ProductInventoryNo);
            var productDetails = new ProductDetails
            {
                Id = product.Id,

                ProductName = product.ProductName,
                ProductDescritpion = product.ProductDescritpion,
                ProductPrice = product.ProductPrice,
                ProductCategoryNo = product.ProductCategoryNo,
                ProductCategory = product.ProductCategory,
                SubCategoryNo = product.SubCategoryNo,
                SubCategory = product.SubCategory,
                SubOfSubCategoryNo = product.SubOfSubCategoryNo,
                SubOfSubCategory = product.SubOfSubCategory,
                ProductInventory = product.ProductInventory,
                ProductInventoryNo = product.ProductInventoryNo,
                ProductDiscountNo = product.ProductDiscountNo,
                ProductDiscount = product.ProductDiscount,
                UserNo = product.UserNo,
                ProductUnit = product.ProductUnit,
                ProductCreatedDate = product.ProductCreatedDate,
                ProductModifiedDate = product.ProductModifiedDate,

               // ProductImages = unitOfWork.GetRepository()..DocumentItems.Where(q => q.RefereneceNumber == product.Id && q.DocumentType == DocumentItemType.ProductImage).ToList()//), e => e.Id, d => d.RefreneceNumber, (Product, ProductImage) => new { product.Id, Productinfo = Product, ProductImage 
            };
            return new ProductDetails();
        }

        public void Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            productRepo.Update(entity);
            unitOfWork.Commit();
        }

        Product IGenericRepository<Product>.GetById(object id)
        {
          return productRepo.GetById(id);
        }
    }
}
