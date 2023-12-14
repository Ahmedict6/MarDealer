using AutoMapper;
using DTOs.Product_DTOs;
using Entities.Models.Product_Management;
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
            CreateMap<Product, ProductPayloadDTO>();
        }
    }
}
