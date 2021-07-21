using AutoMapper;
using Smile.Dtos.OrderDetailDtos;
using Smile.Models;

namespace Smile.Profiles
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetail, OrderDetailReadDto>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();
            CreateMap<OrderDetailUpdateDto, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailUpdateDto>();
        }
    }
}