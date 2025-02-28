namespace OrderFlow.Application.Commands;

public record UpdateShippingStatusCommand : IRequest<UpdateShippingStatusResponse>
{
    public ObjectId OrderId { get; set; }
}

