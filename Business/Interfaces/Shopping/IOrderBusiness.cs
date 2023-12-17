using Business.Coomon;
using DTOs.Common_DTOs;
using DTOs.Shopping_DTOs;
using DTOs.User_DTOs;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using Repository.Interfaces;

namespace Business.Interfaces.Shopping
{
    public interface IOrderBusiness : IGenericRepository<Order>
    {
        void AddOrder(OrderPayloadDTO order);
        List<OrderListDTO> GetAllOrders(Descriptor descriptor);
        List<ExporterDTO> GetExporters();
        OrderDetailsDTO GetOrderDetails(int id);
        List<LookupDTO> GetPaymentTypes();
        void UpdateOrder(OrderPayloadDTO productData);
    }
}
