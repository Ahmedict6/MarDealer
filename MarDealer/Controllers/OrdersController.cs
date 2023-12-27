using Business.Coomon;
using Business.Interfaces.Shopping;
using DTOs.Common_DTOs;
using DTOs.Product_DTOs;
using DTOs.Shopping_DTOs;
using DTOs.User_DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        private readonly IOrderBusiness _orderBussiness;


        public OrdersController(IOrderBusiness productBusiness)
        {
            this._orderBussiness = productBusiness;
        }

        [HttpGet("GetPaymentTypes")]
        public async Task<ApiResponse<List<LookupDTO>>> GetPayments()
        {
            ApiResponse<List<LookupDTO>> _ApiResponse = new ApiResponse<List<LookupDTO>>();
            var product = await Task.Run<List<LookupDTO>>(() => _orderBussiness.GetPaymentTypes());
            if (product == null)
            {
                _ApiResponse.Message = "Not Found";
                Response.StatusCode = 404;
                return _ApiResponse;
            }

            _ApiResponse = new ApiResponse<List<LookupDTO>>();
            _ApiResponse.Data = product;

            return _ApiResponse;

        }
        [HttpGet("GetExporters")]
        public async Task<ApiResponse<List<ExporterDTO>>> GetExporters()
        {
            ApiResponse<List<ExporterDTO>> response = new ApiResponse<List<ExporterDTO>>();
            var product = await Task.Run<List<ExporterDTO>>(() => _orderBussiness.GetExporters());
            if (product == null)
            {
                response.Message = "Not Found";
                Response.StatusCode = 404;
                return response;
            }
            response = new ApiResponse<List<ExporterDTO>>();
            response.Data = product;
            return response;
        }
        [HttpGet("GetExporterDetails")]
        public async Task<ApiResponse<ExporterDTO>> GetExporters(int exporterId)
        {
            ApiResponse<ExporterDTO> response = new ApiResponse<ExporterDTO>();
            var exporter = await Task.Run<ExporterDTO>(() => _orderBussiness.GetExporterDetails(exporterId));
            if (exporter == null)
            {
                response.Message = "Not Found";
                Response.StatusCode = 404;
                return response;
            }
            response.Data = exporter;
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<OrderDetailsDTO>> Get(int id)
        {
            ApiResponse<OrderDetailsDTO> _ApiResponse = new ApiResponse<OrderDetailsDTO>();
            if (id < 1)
            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }
            var product = await Task.Run<OrderDetailsDTO>(() => _orderBussiness.GetOrderDetails(id));
            if (product == null)
            {
                _ApiResponse.Message = "Not Found";
                Response.StatusCode = 404;
                return _ApiResponse;
            }

            _ApiResponse = new ApiResponse<OrderDetailsDTO>();
            _ApiResponse.Data = product;
            return _ApiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse<OrderDetailsDTO>> Post(OrderPayloadDTO order)
        {
            ApiResponse<OrderDetailsDTO> _ApiResponse = new ApiResponse<OrderDetailsDTO>();
            _ApiResponse.Data = _orderBussiness.AddOrder(order);

            _ApiResponse.Message = "added Successfully ";
            return _ApiResponse;
        }
        [HttpPost("/ConfirmOrder")]
        public async Task<ApiResponse<OrderDetailsDTO>> ConfirmOrder(OrderDetailsDTO order)
        {
            ApiResponse<OrderDetailsDTO> _ApiResponse = new ApiResponse<OrderDetailsDTO>();
            _orderBussiness.ConfirmOrder(order);

            _ApiResponse.Message = "confirmed Successfully ";
            return _ApiResponse;
        }

        [HttpPut]
        public async Task<ApiResponse<OrderDetailsDTO>> Put(OrderPayloadDTO orderPayload)
        {
            ApiResponse<OrderDetailsDTO> _ApiResponse = new ApiResponse<OrderDetailsDTO>();
            if (orderPayload == null || orderPayload.Id == 0)
            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }
            _orderBussiness.UpdateOrder(orderPayload);
            _ApiResponse.Message = "Updated Successfully ";
            return _ApiResponse;

        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse<OrderDetailsDTO>> Delete(int id = 0)
        {
            ApiResponse<OrderDetailsDTO> _ApiResponse = new ApiResponse<OrderDetailsDTO>();
            if (id > 1)
            {
                _ApiResponse.Message = "invalid Request";
                Response.StatusCode = 500;
                return _ApiResponse;
            }

            _orderBussiness.Delete(id);

            _ApiResponse.Message = "Deleted Successfully ";
            return _ApiResponse;
        }


        [HttpPost("GetOrders")]
        public Task<ApiResponse<List<OrderListDTO>>> GetOrders(Descriptor descriptor)
        {
            ApiResponse<List<OrderListDTO>> response = new ApiResponse<List<OrderListDTO>>();
            var productList = _orderBussiness.GetAllOrders(descriptor);
            response.Data = productList;
            return Task.FromResult(response);
        }



    }
}
