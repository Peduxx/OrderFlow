namespace OrderFlow.Api.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<CreateOrderRequest, CreateOrderCommand>();
        CreateMap<UpdatePaymentInformationRequest, UpdatePaymentInformationCommand>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => new ObjectId(src.OrderId)));
        CreateMap<UpdatePaymentStatusRequest, UpdatePaymentStatusCommand>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => new ObjectId(src.OrderId)));
        CreateMap<UpdateShippingInformationRequest, UpdateShippingInformationCommand>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => new ObjectId(src.OrderId)));
        CreateMap<UpdateShippingStatusRequest, UpdateShippingStatusCommand>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => new ObjectId(src.OrderId)));
    }
}
