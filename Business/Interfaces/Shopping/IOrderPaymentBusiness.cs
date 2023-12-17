using Business.Coomon;
using DTOs.Shopping_DTOs;
using Entities.Models.Shopping_Management;
using Repository.Interfaces;

namespace Business.Interfaces.Shopping
{
    public interface IOrderPaymentBusiness : IGenericRepository<OrderPayment>
    {
        void AddOrderPayment(OrderPayment order);
        List<OrderPayment> GetAllOrderPayments(Descriptor descriptor);
        OrderPayment GetOrderPaymentDetails(int id);
        void UpdateOrderPayment(OrderPayment productData);
    }
}
