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
    public class SubOfSubCategoryBusiness : ISubOfSubCategoryBusiness
    {
        private readonly IGenericRepository<SubOfSubCategory> productRepo;
        private readonly IUnitOfWork unitOfWork;

        public SubOfSubCategoryBusiness(IGenericRepository<SubOfSubCategory> _productRepo, IUnitOfWork _unitOfWork)
        {

            this.productRepo = _productRepo;
            this.unitOfWork = _unitOfWork;
        }

        public void Delete(object id)
        {
            productRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<SubOfSubCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubOfSubCategory> GetAll(Func<SubOfSubCategory, bool> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubOfSubCategory> GetAllWithChildren(params Expression<Func<SubOfSubCategory, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public SubOfSubCategory GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SubOfSubCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SubOfSubCategory entity)
        {
            productRepo.Update(entity);
            unitOfWork.Commit();
        }

    }
}
