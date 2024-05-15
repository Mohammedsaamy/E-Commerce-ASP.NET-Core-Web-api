using AutoMapper;
using DTOs.Create;
using DTOs.Display;
using DTOs.Update;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mapper
{
    public class MapperProduct : Profile
    {
        public MapperProduct()
        {
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProduct>().ReverseMap();


        }

    }
}
