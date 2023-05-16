using AutoMapper;
using DTO;
using entities;

namespace MyShop
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDto>().
                ForMember(productDto => productDto.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ProductDto, Product>();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            
            CreateMap<User, UserLoginDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();


        }
    }
}
