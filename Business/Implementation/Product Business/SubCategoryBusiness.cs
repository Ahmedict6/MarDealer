using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Entities.Models.Product_Management;
using Repository;
using Entities;
using Business.Interfaces.Common;
using Business.Interfaces.Product_Business;

namespace Business.Implementation.Product_Business
{
    public class SubCategoryBusiness : ISubCategoryBusiness
    {
        private readonly IGenericRepository<SubCategory> productRepo;
        private readonly IUnitOfWork unitOfWork;

        public SubCategoryBusiness(IGenericRepository<SubCategory> _productRepo, IUnitOfWork _unitOfWork)
        {

            this.productRepo = _productRepo;
            this.unitOfWork = _unitOfWork;
        }

        public void Delete(object id)
        {
            productRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<SubCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> GetAll(Func<SubCategory, bool> expression)
        {
            throw new NotImplementedException();
        }

        public SubCategory GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SubCategory entity)
        {
            productRepo.Update(entity);
            unitOfWork.Commit();
        }

    }
}
