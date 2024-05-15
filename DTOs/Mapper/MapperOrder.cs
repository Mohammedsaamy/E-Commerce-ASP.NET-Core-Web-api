using AutoMapper;
using DTOs.Create;
using DTOs.Display;
using DTOs.Update;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mapper
{
    public class MapperOrder : Profile
    {
        public MapperOrder()
        {
            CreateMap<Order, GetAllOrder>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();


        }

    }
    
}
