using AutoMapper;
using Business.Coomon;
using Business.Interfaces.Shopping;
using DTOs.Common_DTOs;
using DTOs.Shopping_DTOs;
using DTOs.User_DTOs;
using Entities.Models.Common;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Business.Implementation.Shopping
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IGenericRepository<Order> orderRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<LookupData> lookupRepo;
        private IGenericRepository<OrderItem> orderItemRepo;
        private IGenericRepository<OrderPayment> paymentRepo;
        private IGenericRepository<ExporterInformation> exporterRepo;
        private IGenericRepository<User> usersRepo;
        private IMapper _mapper;

        public OrderBusiness(IUnitOfWork _unitOfWork,
            IGenericRepository<OrderPayment> _paymentRepo,
        IGenericRepository<OrderItem> _orderItemRepo,
            IGenericRepository<Order> _orderRepo,
             IGenericRepository<ExporterInformation> _exporterRepo,
             IGenericRepository<User> _usersRepo,
             IGenericRepository<LookupData> _lookupRepo,
             IMapper mapper)
        {

            unitOfWork = _unitOfWork;
            orderItemRepo = _orderItemRepo;
            paymentRepo = _paymentRepo;
            orderRepo = _orderRepo;
            this.exporterRepo = _exporterRepo;
            this.usersRepo = _usersRepo;
            this.lookupRepo = _lookupRepo;
            _mapper = mapper;

        }

        public void Delete(object id)
        {
            orderRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll(Func<Order, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<OrderListDTO> GetAllOrders(Descriptor descriptor)
        {
            var query = orderRepo.GetAll().AsQueryable();

            var Orders = DescriptorProccer.QuryExcuter(descriptor, query);

            List<OrderListDTO> orderVms = new List<OrderListDTO>();
            foreach (var Order in Orders)
            {


                OrderListDTO pvm = new OrderListDTO
                {
                    Id = Order.Id,
                    OrderCreatedDate = Order.OrderCreatedDate,
                    OrderModifiedDate = Order.OrderModifiedDate,
                    Total = Order.Total,
                    UserNo = Order.UserNo,
                    UserName = usersRepo.GetAll().FirstOrDefault(q => q.Id == Order.UserNo)?.UserName,
                    //UserLogUrl = documentItemRepo.GetAll().Where(q => q.RefereneceNumber == Order.UserNo && (int)q.DocumentType == (int)DocumentItemType.UserProfileImage).FirstOrDefault().DocumentUrl,

                };
                orderVms.Add(pvm);
            }

            return orderVms;
        }

        public OrderDetailsDTO GetOrderDetails(int id)
        {

            var order = orderRepo.GetById(id);
            if (order == null)
                return new OrderDetailsDTO();
            var exporterInfo = exporterRepo.GetAll(q => q.UserNo == order.UserNo).FirstOrDefault();
            var orderItems = orderItemRepo.GetAll(q => q.OrderNo == order.Id).ToList();
            var payment = paymentRepo.GetAll(q => q.OrderNo == order.Id).FirstOrDefault();
            var paymentDTO = _mapper.Map<OrderPaymentDTO>(payment);
            //var mapper =
            var orderItemsDTO = _mapper.Map<List<OrderItemDTO>>(orderItems);
            var exporterDealsNumber = orderRepo.GetAll(q => q.ExporterNo == order.UserNo).Count();

            var orderDetails = new OrderDetailsDTO
            {
                Id = order.Id,
                ExporterPrice = exporterInfo.FrightPrice,
                ExporterName = usersRepo.GetAll().FirstOrDefault(q => q.Id == order.UserNo)?.FullName,
                ExporterDeals = exporterDealsNumber,
                OrderAdress = "address",// order.OrderPrice,
                OrderAdressMobile = "646566356",// order.OrderCategoryNo,
                ItemTotalTotalPrice = order.Total,
                OrderItems = orderItemsDTO,
                PaymentType = order.PaymentType,
                UserName = usersRepo.GetAll().FirstOrDefault(q => q.Id == order.UserNo)?.UserName,
                OrderPayment = paymentDTO,

                UserNo = order.UserNo,

                OrderCreatedDate = order.OrderCreatedDate,
                OrderModifiedDate = order.OrderModifiedDate,


            };




            return orderDetails;
        }

        public void Insert(Order entity)
        {
            throw new NotImplementedException();
        }
        public void AddOrder(OrderPayloadDTO entity)
        {

            Order order = _mapper.Map<Order>(entity);
            OrderPayment payment = _mapper.Map<OrderPayment>(entity);
            List<OrderItem> orderItems = _mapper.Map<List<OrderItem>>(entity.OrderItems);
            orderRepo.Insert(order);
            paymentRepo.Insert(payment);
            foreach (var item in orderItems)
            {
                orderItemRepo.Insert(item);
            }

        }

        public void UpdateOrder(OrderPayloadDTO entity)
        {

            Order order = _mapper.Map<Order>(entity);

            orderRepo.Update(order);

            unitOfWork.Commit();
        }

        Order IGenericRepository<Order>.GetById(object id)
        {


            return orderRepo.GetById(id);
        }

        public IEnumerable<Order> GetAllWithChildren(params Expression<Func<Order, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<ExporterDTO> GetExporters()
        {
            var exporters = exporterRepo.GetAll();
            var users = usersRepo.GetAll(u => u.UserTypeNo == (int)CommonEnums.UserType.Exporter);
            var query = from user in users
                        join exporter in exporters on user.Id equals exporter.UserNo
                        //  where sa.LocationId == 1
                        select new { user, exporter };
            var result = query.ToList();
            var lookupList = new List<ExporterDTO>();
            foreach (var item in result)
            {
                lookupList.Add(new ExporterDTO() { Id = item.user.Id, ExporterName = item.exporter.ExporterName, ExportPercentage = item.exporter.ExportPercentage, FrightPrice = item.exporter.FrightPrice, SocialInsuracePrice = item.exporter.SocialInsuracePrice, Mobile = item.user.Mobile });
            }
            return lookupList;
        }

        public List<LookupDTO> GetPaymentTypes()
        {
            var lookups = lookupRepo.GetAll(q => q.LookupType == CommonEnums.LookupType.PaymentType.ToString());
            var lookupList = new List<LookupDTO>();
            foreach (var item in lookups)
            {
                lookupList.Add(new LookupDTO() { Id = item.Id, Value = item.LookupValue, Name = item.LookupName, NameAr = item.LookupName });
            }
            return lookupList;
        }
    }
}
