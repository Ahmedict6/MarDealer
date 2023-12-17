using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Repository;

using Business.Coomon;
using Business.Interfaces.Shopping;
using Entities.Models.Common;
using System.Linq.Expressions;
using Entities.Models.User_Management;
using AutoMapper;
using Entities.Models.Shopping_Management;

namespace Business.Implementation.Shopping
{
    public class LookupDataBusiness : ILookupDataBusiness
    {
        private readonly IGenericRepository<LookupData> epxorterRepo;
        private readonly IUnitOfWork unitOfWork;
        //private readonly IGenericRepository<SubCategory> subCategoryRepo;
        //private IGenericRepository<LookupDataInventory> productInventoryReop;
        //private readonly IGenericRepository<DocumentItem> documentItemRepo;
        //private IGenericRepository<LookupDataCategory> productCategoryRepo;
        private IGenericRepository<UsersComment> usersCommentrRepo;
        private IGenericRepository<User> usersRepo;
        private   IMapper _mapper;

        public LookupDataBusiness(IUnitOfWork _unitOfWork,
            //IGenericRepository<SubCategory> _subCategoryRepo,
            //IGenericRepository<LookupDataCategory> _productCategoryRepo,
            //IGenericRepository<SubOfSubCategory> _subOfSubCategoryRepo,
            //IGenericRepository<DocumentItem> _documentItemRepo,
            //IGenericRepository<LookupDataInventory> _productInventoryReop,
            IGenericRepository<LookupData> _epxorterRepo,
            //IGenericRepository<LookupDataSpecification> _productSpecificationRepo,
             IGenericRepository<UsersComment> _usersCommentrRepo,
             IGenericRepository<User> _usersRepo,
             IMapper mapper)
        {

            unitOfWork = _unitOfWork;
            //subCategoryRepo = _subCategoryRepo;
            //productCategoryRepo = _productCategoryRepo;
            //subOfSubCategoryRepo = _subOfSubCategoryRepo;
            //productInventoryReop = _productInventoryReop;
            //documentItemRepo = _documentItemRepo;
            epxorterRepo = _epxorterRepo;
            this.usersCommentrRepo = _usersCommentrRepo;
            this.usersRepo = _usersRepo;
            _mapper = mapper;

        }

        public void Delete(object id)
        {
            epxorterRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<LookupData> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LookupData> GetAll(Func<LookupData, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<LookupData> GetAllLookupDatas(Descriptor descriptor)
        {
            var query = epxorterRepo.GetAll().AsQueryable();

           var LookupDatas = DescriptorProccer.QuryExcuter(descriptor, query);

            List<LookupData> orderVms = new List<LookupData>();
           

            return orderVms;
        }

        public LookupData GetLookupDataDetails(int id)
        {

            var exporter = epxorterRepo.GetAllWithChildren(
                //p => p.SubCategory,
                //p => p.LookupDataCategory,
                //p => p.LookupDataInventory,
                //p => p.LookupDataDiscount
                ).FirstOrDefault(p => p.Id == id);


            




            return exporter;
        }

        public void Insert(LookupData entity)
        {
            throw new NotImplementedException();
        }
        public void AddLookupData(LookupData entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateLookupData(LookupData entity)
        {

            LookupData order = _mapper.Map<LookupData>(entity);




            epxorterRepo.Update(order);

    



          
            unitOfWork.Commit();
        }

        LookupData GetById(object id)
        {


            return epxorterRepo.GetById(id);
        }

        public IEnumerable<LookupData> GetAllWithChildren(params Expression<Func<LookupData, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(LookupData entity)
        {
            throw new NotImplementedException();
        }

        public void AddExporter(LookupData exporter)
        {
            throw new NotImplementedException();
        }

        public List<LookupData> GetAllExporters(Descriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public LookupData GetExporterDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateExporter(LookupData exporter)
        {
            throw new NotImplementedException();
        }

        LookupData IGenericRepository<LookupData>.GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
