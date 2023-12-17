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
    public class UserBusiness : IUserBusiness
    {
        private readonly IGenericRepository<Order> orderRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<LookupData> lookupRepo;
        private IGenericRepository<OrderItem> orderItemRepo;
        private IGenericRepository<OrderPayment> paymentRepo;
        private IGenericRepository<ExporterInformation> exporterRepo;
        private IGenericRepository<User> usersRepo;
        private IMapper _mapper;

        public UserBusiness(IUnitOfWork _unitOfWork,
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
            usersRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll(Func<User, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<UserListDTO> GetAllUsers(Descriptor descriptor)
        {
            var query = usersRepo.GetAll().AsQueryable();

            var Users = DescriptorProccer.QuryExcuter(descriptor, query);

            List<UserListDTO> orderVms = new List<UserListDTO>();
            foreach (var User in Users)
            {


                UserListDTO pvm = new UserListDTO
                {
                    Id = User.Id,
                    UserCreatedDate = User.UserCreatedDate,
                    UserModifiedDate = User.UserModifiedDate,
                    //Total = User.Total,
                    //UserNo = User.UserNo,
                    //UserName = usersRepo.GetAll().FirstOrDefault(q => q.Id == User.UserNo)?.UserName,
                    //UserLogUrl = documentItemRepo.GetAll().Where(q => q.RefereneceNumber == User.UserNo && (int)q.DocumentType == (int)DocumentItemType.UserProfileImage).FirstOrDefault().DocumentUrl,

                };
                orderVms.Add(pvm);
            }

            return orderVms;
        }

        public UserDetailsDTO GetUserDetails(int id)
        {

            var order = orderRepo.GetById(id);
            if (order == null)
                return new UserDetailsDTO();
            var exporterInfo = exporterRepo.GetAll(q => q.UserNo == order.UserNo).FirstOrDefault();
            //var orderItems = orderItemRepo.GetAll(q => q.UserNo == order.Id).ToList();
            //var payment = paymentRepo.GetAll(q => q.UserNo == order.Id).FirstOrDefault();
            //var paymentDTO = _mapper.Map<OrderPaymentDTO>(payment);
            ////var mapper =
            //var orderItemsDTO = _mapper.Map<List<UserItemDTO>>(orderItems);
            var exporterDealsNumber = orderRepo.GetAll(q => q.ExporterNo == order.UserNo).Count();

            var orderDetails = new UserDetailsDTO
            {
                Id = order.Id,
                //ExporterPrice = exporterInfo.FrightPrice,
                //ExporterName = usersRepo.GetAll().FirstOrDefault(q => q.Id == order.UserNo)?.FullName,
                //ExporterDeals = exporterDealsNumber,
                //OrderAdress = "address",// order.OrderPrice,
                //OrderAdressMobile = "646566356",// order.OrderCategoryNo,
                //ItemTotalTotalPrice = order.Total,
                //OrderItems = orderItemsDTO,
                //PaymentType = order.PaymentType,
                //UserName = usersRepo.GetAll().FirstOrDefault(q => q.Id == order.UserNo)?.UserName,
                //OrderPayment = paymentDTO,

                //UserNo = order.UserNo,

                //OrderCreatedDate = order.OrderCreatedDate,
                //OrderModifiedDate = order.OrderModifiedDate,


            };




            return orderDetails;
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }
        public void AddUser(UserPayloadDTO entity)
        {

            User order = _mapper.Map<User>(entity);
            //UserPayment payment = _mapper.Map<UserPayment>(entity);
            //List<OrderItem> orderItems = _mapper.Map<List<OrderItem>>(entity.OrderItems);
            //orderRepo.Insert(order);
            //paymentRepo.Insert(payment);
            //foreach (var item in orderItems)
            //{
            //    orderItemRepo.Insert(item);
            //}

        }

        public void UpdateUser(UserPayloadDTO entity)
        {

            User order = _mapper.Map<User>(entity);

            usersRepo.Update(order);

            unitOfWork.Commit();
        }

        User IGenericRepository<User>.GetById(object id)
        {


            return usersRepo.GetById(id);
        }

        public IEnumerable<User> GetAllWithChildren(params Expression<Func<User, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
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

        public List<LookupDTO> GetUserTypes()
        {
            var lookups = lookupRepo.GetAll(q => q.LookupType == CommonEnums.LookupType.UserType.ToString());
            var lookupList = new List<LookupDTO>();
            foreach (var item in lookups)
            {
                lookupList.Add(new LookupDTO() { Id = item.Id, Value = item.LookupValue, Name = item.LookupName, NameAr = item.LookupName });
            }
            return lookupList;
        }

        public void ChangePassword(ChangePasswordDTO user)
        {
            throw new NotImplementedException();
        }

        public void ForgetPassword(ForgetPasswordDTO user)
        {
            throw new NotImplementedException();
        }

        public void Login(LoginDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
