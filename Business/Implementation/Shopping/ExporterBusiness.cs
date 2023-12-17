using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Repository;

using Business.Coomon;
using Business.Interfaces.Shopping;
using Entities.Models.Common;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Entities.Models.User_Management;
using AutoMapper;

namespace Business.Implementation.Shopping
{
    public class ExporterBusiness : IExporterBusiness
    {
        private readonly IGenericRepository<ExporterInformation> epxorterRepo;
        private readonly IUnitOfWork unitOfWork;
        //private readonly IGenericRepository<SubCategory> subCategoryRepo;
        //private IGenericRepository<ExporterInformationInventory> productInventoryReop;
        //private readonly IGenericRepository<DocumentItem> documentItemRepo;
        //private IGenericRepository<ExporterInformationCategory> productCategoryRepo;
        private IGenericRepository<UsersComment> usersCommentrRepo;
        private IGenericRepository<User> usersRepo;
        private   IMapper _mapper;

        public ExporterBusiness(IUnitOfWork _unitOfWork,
            //IGenericRepository<SubCategory> _subCategoryRepo,
            //IGenericRepository<ExporterInformationCategory> _productCategoryRepo,
            //IGenericRepository<SubOfSubCategory> _subOfSubCategoryRepo,
            //IGenericRepository<DocumentItem> _documentItemRepo,
            //IGenericRepository<ExporterInformationInventory> _productInventoryReop,
            IGenericRepository<ExporterInformation> _epxorterRepo,
            //IGenericRepository<ExporterInformationSpecification> _productSpecificationRepo,
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

        public IEnumerable<ExporterInformation> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExporterInformation> GetAll(Func<ExporterInformation, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<ExporterInformation> GetAllExporterInformations(Descriptor descriptor)
        {
            var query = epxorterRepo.GetAll().AsQueryable();

           var ExporterInformations = DescriptorProccer.QuryExcuter(descriptor, query);

            List<ExporterInformation> orderVms = new List<ExporterInformation>();
           

            return orderVms;
        }

        public ExporterInformation GetExporterInformationDetails(int id)
        {

            var exporter = epxorterRepo.GetAllWithChildren(
                //p => p.SubCategory,
                //p => p.ExporterInformationCategory,
                //p => p.ExporterInformationInventory,
                //p => p.ExporterInformationDiscount
                ).FirstOrDefault(p => p.Id == id);


           // var productImages = documentItemRepo.GetAll().Where(q => q.RefereneceNumber == product.Id && (int)q.DocumentType == (int)DocumentItemType.ExporterInformationImage).ToList();
           // var productComment = usersCommentrRepo.GetAll()?.Where(q => q.RefranceNumber == product.Id && (int)q.CommentType == (int)CommentType.ExporterInformationComment)?.ToList();
            //var ExporterInformationSpecification = productSpecificationRepo.GetAll()?.Where(q => q.ExporterInformationNo == product.Id)?.ToList();


            




            return exporter;
        }

        public void Insert(ExporterInformation entity)
        {
            throw new NotImplementedException();
        }
        public void AddExporterInformation(ExporterInformation entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateExporterInformation(ExporterInformation entity)
        {

            ExporterInformation order = _mapper.Map<ExporterInformation>(entity);




            epxorterRepo.Update(order);

            //foreach (var item in entity.Images)
            //{


            //    var documrntGuid = new Guid; 
            //    var doc = new DocumentItem {
            //        DocuemntName = documrntGuid,
            //        DocumentType = DocumentItemType.ExporterInformationImage,
            //        RefereneceNumber = entity.Id

            //    }
            //    documentItemRepo.Update(entity);

            //}



          
            unitOfWork.Commit();
        }

        ExporterInformation IGenericRepository<ExporterInformation>.GetById(object id)
        {


            return epxorterRepo.GetById(id);
        }

        public IEnumerable<ExporterInformation> GetAllWithChildren(params Expression<Func<ExporterInformation, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(ExporterInformation entity)
        {
            throw new NotImplementedException();
        }

        public void AddExporter(ExporterInformation exporter)
        {
            throw new NotImplementedException();
        }

        public List<ExporterInformation> GetAllExporters(Descriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public ExporterInformation GetExporterDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateExporter(ExporterInformation exporter)
        {
            throw new NotImplementedException();
        }
    }
}
