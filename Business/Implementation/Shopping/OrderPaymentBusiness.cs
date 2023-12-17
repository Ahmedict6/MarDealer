using AutoMapper;
using Business.Coomon;
using Business.Interfaces.Shopping;
using Entities.Models.Common;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Business.Implementation.Shopping
{
    public class OrderPaymentBusiness : IOrderPaymentBusiness
    {
        private readonly IGenericRepository<OrderPayment> orderRepo;
        private readonly IUnitOfWork unitOfWork;
        private IGenericRepository<UsersComment> usersCommentrRepo;
        private IGenericRepository<User> usersRepo;
        private   IMapper _mapper;

        public OrderPaymentBusiness(IUnitOfWork _unitOfWork,
            IGenericRepository<OrderPayment> _orderRepo,
             IGenericRepository<UsersComment> _usersCommentrRepo,
             IGenericRepository<User> _usersRepo,
             IMapper mapper)
        {

            unitOfWork = _unitOfWork;
            orderRepo = _orderRepo;
            this.usersCommentrRepo = _usersCommentrRepo;
            this.usersRepo = _usersRepo;
            _mapper = mapper;

        }

        public void Delete(object id)
        {
            orderRepo.Delete(id);
            unitOfWork.Commit();
        }

        public IEnumerable<OrderPayment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderPayment> GetAll(Func<OrderPayment, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<OrderPayment> GetAllOrderPayments(Descriptor descriptor)
        {
            var query = orderRepo.GetAll().AsQueryable();

           var OrderPayments = DescriptorProccer.QuryExcuter(descriptor, query).ToList<OrderPayment>();

            return OrderPayments;
        }

        public OrderPayment GetOrderPaymentDetails(int id)
        {

            var payment = orderRepo.GetAll(p => p.Id == id).FirstOrDefault();
            return payment;
        }

        public void Insert(OrderPayment entity)
        {
            throw new NotImplementedException();
        }
        public void AddOrderPayment(OrderPayment entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderPayment(OrderPayment entity)
        {

            OrderPayment order = _mapper.Map<OrderPayment>(entity);
            orderRepo.Update(order);
            unitOfWork.Commit();
        }

        OrderPayment GetById(object id)
        {
            return orderRepo.GetById(id);
        }

        public IEnumerable<OrderPayment> GetAllWithChildren(params Expression<Func<OrderPayment, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderPayment entity)
        {
            throw new NotImplementedException();
        }

        OrderPayment IGenericRepository<OrderPayment>.GetById(object id)
        {
            return orderRepo.GetById(id);
        }
    }
}
