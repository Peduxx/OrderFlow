namespace OrderFlow.Application.Commands;

public record UpdatePaymentStatusCommand : IRequest<UpdatePaymentStatusResponse>
{
    public ObjectId OrderId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string? Message { get; set; }
}

