using MiniShop.Models.DTO;
using MiniShop.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace MiniShop
{
    public class AutoMapperConfg : Profile
    {
        public AutoMapperConfg()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Blog, BlogDTO>().ReverseMap();
        }
    }
}
