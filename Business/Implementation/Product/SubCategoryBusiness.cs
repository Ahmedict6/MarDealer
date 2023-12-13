using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Entities.Models.Product_Management;
using Repository;
using Entities;
using Business.Interfaces.Common;
using Business.Interfaces.Product;

namespace Business.Implementation.Product
{
    public class SubCategoryBusiness : ISubCategoryBusiness
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IUnitOfWork unitOfWork;

        public SubCategoryBusiness(IGenericRepository<Product> _productRepo, IUnitOfWork _unitOfWork)
        {

            this.productRepo = _productRepo;
            this.unitOfWork = _unitOfWork;
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

        public Product GetById(object id)
        {
            throw new NotImplementedException();
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

    }
}
