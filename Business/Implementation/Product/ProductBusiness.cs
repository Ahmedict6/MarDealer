using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Entities.Models.Product_Management;
using Repository;
using Entities;
using DTOs.Product_DTOs;
using Business.Coomon;
using Microsoft.EntityFrameworkCore;
using static Entities.Models.Common.DocumentItem;

namespace Business.Implementation.Product
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IUnitOfWork unitOfWork;

        public ProductBusiness(IUnitOfWork _unitOfWork,
            //IGenericRepository<Product> _productRepo,
            //IGenericRepository<Product> _productRepo,
            //IGenericRepository<Product> _productRepo,
            //IGenericRepository<Product> _productRepo,
            IGenericRepository<Product> _productRepo)
        {

            productRepo = _productRepo;
            unitOfWork = _unitOfWork;
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

        public ProductDetails GetById(object id)
        {
            var product =  unitOfWork.GetRepository<Product>().GetById(id);
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

                //ProductImages = unitOfWork.GetRepository()..DocumentItems.Where(q => q.RefereneceNumber == product.Id && q.DocumentType == DocumentItemType.ProductImage).ToList()//), e => e.Id, d => d.RefreneceNumber, (Product, ProductImage) => new { product.Id, Productinfo = Product, ProductImage 
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
            throw new NotImplementedException();
        }
    }
}
