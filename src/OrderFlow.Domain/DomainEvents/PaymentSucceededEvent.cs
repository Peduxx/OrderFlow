namespace OrderFlow.Domain.DomainEvents;

public record PaymentSucceededEvent : IDomainEvent
{
    public ObjectId OrderId { get; }
    public ObjectId CustomerId { get; }
    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public OrderStatus OldStatus { get; }
    public OrderStatus NewStatus { get; }

    public ObjectId Id => ObjectId.GenerateNewId();
    public string Type => "PaymentSucceeded";
    public DateTime OccurredOn => DateTime.UtcNow;

    public PaymentSucceededEvent(ObjectId orderId, ObjectId customerId, string customerName, string customerEmail, OrderStatus oldStatus, OrderStatus newStatus)
    {
        OrderId = orderId;
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        OldStatus = oldStatus;
        NewStatus = newStatus;
    }
}