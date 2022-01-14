using AutoMapper;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Application.Profiles
{
     public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
            // CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            // CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}