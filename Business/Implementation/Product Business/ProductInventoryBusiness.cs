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
    public class ProductInventoryBusiness : IProductInventoryBusiness
    {
        private readonly IGenericRepository<ProductInventory> productRepo;
        private readonly IUnitOfWork unitOfWork;

        public ProductInventoryBusiness(IGenericRepository<ProductInventory> _productRepo, IUnitOfWork _unitOfWork)
        {

            this.productRepo = _productRepo;
            this.unitOfWork = _unitOfWork;
        }

        public void Delete(object id)
        {
            productRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<ProductInventory> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductInventory> GetAll(Func<ProductInventory, bool> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductInventory> GetAllWithChildren(params Expression<Func<ProductInventory, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public ProductInventory GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductInventory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductInventory entity)
        {
            productRepo.Update(entity);
            unitOfWork.Commit();
        }

    }
}
