using Business.Coomon;
using DTOs.Shopping_DTOs;
using Entities.Models.Shopping_Management;
using Repository.Interfaces;

namespace Business.Interfaces.Shopping
{
    public interface IOrderItemBusiness : IGenericRepository<OrderItem>
    {
        void AddOrderItem(OrderItem order);
        List<OrderItem> GetAllOrderItems(Descriptor descriptor);
        OrderItem GetOrderItemDetails(int id);
        void UpdateOrderItem(OrderItem productData);
    }
}
