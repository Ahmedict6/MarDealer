using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Entities.Models.Product_Management;
using Repository;
using Entities;
using Business.Interfaces.Common;
using Business.Interfaces.Product_Business;
using System.Linq.Expressions;

namespace Business.Implementation.Product_Business
{
    public class ProductCategoryBusiness : IProductCategoryBusiness
    {
        private readonly IGenericRepository<ProductCategory> productRepo;
        private readonly IUnitOfWork unitOfWork;

        public ProductCategoryBusiness(IGenericRepository<ProductCategory> _productRepo, IUnitOfWork _unitOfWork)
        {

            this.productRepo = _productRepo;
            this.unitOfWork = _unitOfWork;
        }

        public void Delete(object id)
        {
            productRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAll(Func<ProductCategory, bool> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAllWithChildren(params Expression<Func<ProductCategory, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory entity)
        {
            productRepo.Update(entity);
            unitOfWork.Commit();
        }

    }
}
