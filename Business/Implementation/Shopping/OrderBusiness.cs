using AutoMapper;
using Business.Coomon;
using Business.Interfaces.Shopping;
using DTOs.Common_DTOs;
using DTOs.Shopping_DTOs;
using DTOs.User_DTOs;
using Entities.Models.Common;
using Entities.Models.Product_Management;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Repository.Interfaces;
using System.Linq.Expressions;
using Twilio.TwiML.Voice;

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
        private IGenericRepository<Product> productRepo;
        private IGenericRepository<UsersComment> usersCommentrRepo;
        private IMapper _mapper;

        public OrderBusiness(IUnitOfWork _unitOfWork,
            IGenericRepository<OrderPayment> _paymentRepo,
        IGenericRepository<OrderItem> _orderItemRepo,
            IGenericRepository<Order> _orderRepo,
             IGenericRepository<ExporterInformation> _exporterRepo,
             IGenericRepository<User> _usersRepo,
             IGenericRepository<LookupData> _lookupRepo,
             IGenericRepository<Product> _productRepo,
             IGenericRepository<UsersComment> _usersCommentrRepo,
             IMapper mapper)
        {

            unitOfWork = _unitOfWork;
            orderItemRepo = _orderItemRepo;
            paymentRepo = _paymentRepo;
            orderRepo = _orderRepo;
            this.exporterRepo = _exporterRepo;
            this.usersRepo = _usersRepo;
            this.lookupRepo = _lookupRepo;
            this.productRepo = _productRepo;
            this.usersCommentrRepo = _usersCommentrRepo;
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
            var exporterDealsNumber = orderRepo.GetAll(q => q.ExporterNo == order.ExporterNo).Count();
            var paymentType = lookupRepo.GetById(order.OrderPaymentNo)?.LookupName;

            var orderDetails = new OrderDetailsDTO
            {
                Id = order.Id,
                ExporterPrice = exporterInfo.FrightPrice,
                ExporterName = usersRepo.GetAll().FirstOrDefault(q => q.Id == order.UserNo)?.FullName,
                ExporterDeals = exporterDealsNumber,
                OrderAddress =  order.OrderAddress,
                OrderAddressMobile =order.OrderAddressMobile,
                ItemTotalTotalPrice = order.Total,
                OrderItems = orderItemsDTO,
                PaymentType = paymentType,
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
            orderRepo.Insert(entity);
        }
        public OrderDetailsDTO AddOrder(OrderPayloadDTO entity)
        {
            //mapping
            //adding item , but we need to check dsicount availability

            var orderDetails= new OrderDetailsDTO();
            var orderItemsDetails = new List<OrderItemDTO>();
            Order order = _mapper.Map<Order>(entity);
            //OrderPayment payment = _mapper.Map<OrderPayment>(entity);
            List<OrderItem> orderItems = _mapper.Map<List<OrderItem>>(entity.OrderItems);
            var ids = orderItems.Select(q=>q.ProductNo).ToArray<int>();
            // this is if it's transfer paymenttype we admin needs to approve tha order
           
                var products = this.productRepo.GetAllWithChildren(e=>e.ProductDiscount).Where(e => ids.Contains(e.Id)).ToList();
                //   order.sta
                decimal total = 0;

            foreach (var item in orderItems)
            { //item.
                var product = products.Where(e => e.Id == item.ProductNo).First();
                total = item.Quantity * product.ProductPrice;
                var div = (decimal.Divide(product?.ProductDiscount?.DiscountPercent??0, 100));
                item.DiscountAmount = div * total;
                item.DiscountDescription = product?.ProductDiscount?.DiscountDescritpion;
                item.TotalAmount = total - item.DiscountAmount;
                item.ProductName = product.ProductName;
        // orderItemRepo.Insert(item);
    }
            order.Total = orderItems.Sum(q => q.TotalAmount);
            order.TotalDiscount = orderItems.Sum(q => q.DiscountAmount);
            order.OrderItems = orderItems;

            //foreach (var item in orderItems)
            //{ //item.
            //    item.OrderNo = order.Id;
            //    orderItemRepo.Insert(item);
            //}
            ///payment
            var payment = new OrderPayment();
            payment.OrderNo = order.Id;
            payment.PaymentCreatedDate = DateTime.Now;
            payment.PaymentModifiedDate = DateTime.Now;
            payment.Amount = orderItems.Sum(q => q.TotalAmount);
            if (entity.PaymentTypeNo == 3)
            {  // call api for online payment
            }
            else
            {//pending for approval
                payment.Status = 2;
            }
            order.OrderPayment = payment;
            //orderRepo.Insert(order);
            //unitOfWork.Commit();
            //var orderFullDetails = this.GetOrderDetails(order.Id);
            var orderFullDetails = _mapper.Map<OrderDetailsDTO>(order);
            orderFullDetails.ExporterName = usersRepo.GetAll().FirstOrDefault(q => q.Id == order.UserNo)?.FullName;
            var exporterDealsNumber = orderRepo.GetAll(q => q.ExporterNo == order.ExporterNo).Count();
            orderFullDetails.ExporterDeals = exporterDealsNumber;
            orderFullDetails.OrderAddress = order.OrderAddress;
            orderFullDetails.OrderAddressMobile = order.OrderAddressMobile;
            return orderFullDetails;
        }

        public OrderDetailsDTO ConfirmOrder(OrderDetailsDTO entity)
        {
            Order order = _mapper.Map<Order>(entity);
            order.UserName = "";
            order.Total = order.OrderItems.Sum(q => q.TotalAmount);
            order.TotalDiscount = order.OrderItems.Sum(q => q.DiscountAmount);
            orderRepo.Insert(order);
            unitOfWork.Commit();

            OrderDetailsDTO details = _mapper.Map<OrderDetailsDTO>(order);
            return details;
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
            // var exporterType = 3;
            //var users = usersRepo.GetAll(q=>q.UserTypeNo==exporterType);

            // var exporterList = new List<ExporterDTO>();
            // foreach (var item in users)
            // {
            //     exporterList.Add(new ExporterDTO() { Id = item.Id, ExporterName = item.FullName});
            // }
            var exporters = exporterRepo.GetAll();
            // var lookupValue=
            //var productComment = usersCommentrRepo.GetAll()?.Where(q => q.RefranceNumber == product.Id && (int)q.CommentType == (int)CommentType.ProductComment)?.ToList();
            var users = usersRepo.GetAll();
            var query = from user in users
                        join exporter in exporters on user.Id equals exporter.UserNo
                        //  where sa.LocationId == 1
                        select new { user, exporter };
            var result = query.ToList();
            var lookupList = new List<ExporterDTO>();
            foreach (var item in result)
            {
                lookupList.Add(new ExporterDTO() { Id = item.user.Id, ExporterName = item.user.FullName, ExportPercentage = item.exporter.ExportPercentage, FrightPrice = item.exporter.FrightPrice, SocialInsuracePrice = item.exporter.SocialInsuracePrice, Mobile = item.user.Mobile });
            }
            return lookupList;
            //return exporterList;
        }
        public ExporterDTO GetExporterDetails(int exporterId)
        {
            var exporters = exporterRepo.GetAll(q=>q.UserNo==exporterId);
            // var lookupValue=
            var customersComments = usersCommentrRepo.GetAll()?.Where(q => q.RefranceNumber == exporterId && (int)q.CommentType == (int)CommentType.ProductComment)?.ToList();
            var users = usersRepo.GetAll(q => q.Id == exporterId);
            var query = from user in users
                        join exporter in exporters on user.Id equals exporter.UserNo
                        //  where sa.LocationId == 1
                        select new { user, exporter };
            var result = query.FirstOrDefault();

            var exporterDTO = new ExporterDTO() { Id = result.user.Id, ExporterName = result.user.FullName, ExportPercentage = result.exporter.ExportPercentage, FrightPrice = result.exporter.FrightPrice, SocialInsuracePrice = result.exporter.SocialInsuracePrice, Mobile = result.user.Mobile };
            
            var comments=_mapper.Map<List<UsersCommentDTO>>(customersComments);
            exporterDTO.PeopleComments = comments;
            return exporterDTO;
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
