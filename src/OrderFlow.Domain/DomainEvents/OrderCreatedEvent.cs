namespace OrderFlow.Domain.DomainEvents;

public record OrderCreatedEvent : IDomainEvent
{
    public ObjectId OrderId { get; }
    public ObjectId CustomerId { get; }
    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public decimal TotalAmount { get; }
    public OrderStatus Status { get; }
    public ShippingAddress ShippingAddress { get; }
    public PaymentInformation PaymentInformation { get; }

    public ObjectId Id => ObjectId.GenerateNewId();
    public string Type => "OrderCreated";
    public DateTime OccurredOn => DateTime.UtcNow;

    public OrderCreatedEvent(ObjectId orderId, ObjectId customerId, string customerName, string customerEmail, decimal totalAmount, OrderStatus status, ShippingAddress shippingAddress, PaymentInformation paymentInformation)
    {
        OrderId = orderId;
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        TotalAmount = totalAmount;
        Status = status;
        ShippingAddress = shippingAddress;
        PaymentInformation = paymentInformation;
    }
}