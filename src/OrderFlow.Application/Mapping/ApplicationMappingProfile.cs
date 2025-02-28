namespace OrderFlow.Application.Mapping;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<CreateOrderCommand, Order>()
            .ConstructUsing(
                src => Order.Create(
                src.CustomerId,
                src.CustomerName,
                src.CustomerEmail,
                src.OrderItems.Select(id => new OrderItem(id)).ToList(),
                src.TotalAmount,
                ShippingAddress.Create(src.Street, src.Number, src.Complement, src.Neighborhood, src.City, src.State, src.Country, src.ZipCode),
                PaymentInformation.Create(src.CardHolderName, src.CardNumber, src.CardCode, src.CardExpiration)
            ));

        CreateMap<UpdatePaymentInformationCommand, PaymentInformation>()
            .ConstructUsing(
                src => PaymentInformation.Create(
                src.CardHolderName,
                src.CardNumber,
                src.CardCode,
                src.CardExpiration
            ));

        CreateMap<UpdateShippingInformationCommand, ShippingAddress>()
            .ConstructUsing(
                src => ShippingAddress.Create(
                src.Street,
                src.Number,
                src.Complement,
                src.Neighborhood,
                src.City,
                src.State,
                src.Country,
                src.ZipCode
            ));
    }
}