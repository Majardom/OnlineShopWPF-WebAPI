using AutoMapper;
using BLL.DTO;
using DAL.DataEntities;

namespace BLL.AutoMapperConfiguration
{
    public static class AutoMapperConfiguration 
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>()
                    .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                    .ForMember(destination => destination.DateOfCreation,opt => opt.MapFrom(source => source.DateOfCreation))
                    .ForMember(destination => destination.Products, opt => opt.MapFrom(source => source.Products)).MaxDepth(1)
                    .ForMember(destination => destination.StageId, opt => opt.MapFrom(source => source.Stage.Id)).MaxDepth(1)
                    .ReverseMap();

                cfg.CreateMap<Product, ProductDto>()
                    .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                    .ForMember(destination => destination.Caption, opt => opt.MapFrom(source => source.Caption))
                    .ForMember(destination => destination.Price, opt => opt.MapFrom(source => source.Price))
                    .ForMember(destination => destination.CategoryId, opt => opt.MapFrom(source => source.Category.Id)).MaxDepth(1)
                    .ReverseMap();

                cfg.CreateMap<Stage, StageDto>()
                    .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                    .ForMember(destination => destination.Caption, opt => opt.MapFrom(source => source.Caption))
                    .ReverseMap();
            });
        }
    }
}
