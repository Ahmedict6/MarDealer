using AutoMapper;
using DTOs.Common_DTOs;
using DTOs.Product_DTOs;
using DTOs.Shopping_DTOs;
using DTOs.User_DTOs;
using Entities.Models.Common;
using DTOs.User_DTOs;
using Entities.Models.Product_Management;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Common
{
    public class AutoMapperConfig: Profile
    {

        public AutoMapperConfig()
        {
            // CreateMap<Product, ProductPayloadDTO>();
            CreateMap<ProductPayloadDTO, Product>();
            CreateMap<UsersCommentDTO, UsersComment>();
            CreateMap<ProductSpecification, ProductSpecificationDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderPayment, OrderPaymentDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
