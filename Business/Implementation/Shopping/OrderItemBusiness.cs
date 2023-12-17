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
    public class OrderItemBusiness : IOrderItemBusiness
    {
        private readonly IGenericRepository<OrderItem> epxorterRepo;
        private readonly IUnitOfWork unitOfWork;
        //private readonly IGenericRepository<SubCategory> subCategoryRepo;
        //private IGenericRepository<OrderItemInventory> productInventoryReop;
        //private readonly IGenericRepository<DocumentItem> documentItemRepo;
        //private IGenericRepository<OrderItemCategory> productCategoryRepo;
        private IGenericRepository<UsersComment> usersCommentrRepo;
        private IGenericRepository<User> usersRepo;
        private   IMapper _mapper;

        public OrderItemBusiness(IUnitOfWork _unitOfWork,
            //IGenericRepository<SubCategory> _subCategoryRepo,
            //IGenericRepository<OrderItemCategory> _productCategoryRepo,
            //IGenericRepository<SubOfSubCategory> _subOfSubCategoryRepo,
            //IGenericRepository<DocumentItem> _documentItemRepo,
            //IGenericRepository<OrderItemInventory> _productInventoryReop,
            IGenericRepository<OrderItem> _epxorterRepo,
            //IGenericRepository<OrderItemSpecification> _productSpecificationRepo,
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

        public IEnumerable<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> GetAll(Func<OrderItem, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetAllOrderItems(Descriptor descriptor)
        {
            var query = epxorterRepo.GetAll().AsQueryable();

           var OrderItems = DescriptorProccer.QuryExcuter(descriptor, query);

            List<OrderItem> orderVms = new List<OrderItem>();
           

            return orderVms;
        }

        public OrderItem GetOrderItemDetails(int id)
        {

            var exporter = epxorterRepo.GetAllWithChildren(
                //p => p.SubCategory,
                //p => p.OrderItemCategory,
                //p => p.OrderItemInventory,
                //p => p.OrderItemDiscount
                ).FirstOrDefault(p => p.Id == id);


            




            return exporter;
        }

        public void Insert(OrderItem entity)
        {
            throw new NotImplementedException();
        }
        public void AddOrderItem(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderItem(OrderItem entity)
        {

            OrderItem order = _mapper.Map<OrderItem>(entity);




            epxorterRepo.Update(order);

    



          
            unitOfWork.Commit();
        }

        OrderItem GetById(object id)
        {


            return epxorterRepo.GetById(id);
        }

        public IEnumerable<OrderItem> GetAllWithChildren(params Expression<Func<OrderItem, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public void AddExporter(OrderItem exporter)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetAllExporters(Descriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public OrderItem GetExporterDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateExporter(OrderItem exporter)
        {
            throw new NotImplementedException();
        }

        OrderItem IGenericRepository<OrderItem>.GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
