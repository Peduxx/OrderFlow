namespace OrderFlow.Domain.DomainEvents;

public record PaymentFailedEvent : IDomainEvent
{
    public ObjectId OrderId { get; }
    public ObjectId CustomerId { get; }
    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public OrderStatus OldStatus { get; }
    public OrderStatus NewStatus { get; }
    public string Reason { get; }

    public ObjectId Id => ObjectId.GenerateNewId();
    public string Type => "PaymentFailed";
    public DateTime OccurredOn => DateTime.UtcNow;

    public PaymentFailedEvent(ObjectId orderId, ObjectId customerId, string customerName, string customerEmail, OrderStatus oldStatus, OrderStatus newStatus, string reason)
    {
        OrderId = orderId;
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        OldStatus = oldStatus;
        NewStatus = newStatus;
        Reason = reason;
    }
}

