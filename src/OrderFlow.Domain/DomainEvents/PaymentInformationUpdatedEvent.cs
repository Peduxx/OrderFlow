namespace OrderFlow.Domain.DomainEvents;

public record PaymentInformationUpdatedEvent : IDomainEvent
{
    public ObjectId OrderId { get; }
    public ObjectId CustomerId { get; }
    public decimal TotalAmount { get; }
    public PaymentInformation OldPaymentInformation { get; }
    public PaymentInformation NewPaymentInformation { get; }

    public ObjectId Id => ObjectId.GenerateNewId();
    public string Type => "PaymentInformationUpdated";
    public DateTime OccurredOn => DateTime.UtcNow;

    public PaymentInformationUpdatedEvent(ObjectId orderId, ObjectId customerId, decimal totalAmount, PaymentInformation oldPaymentInformation, PaymentInformation newPaymentInformation)
    {
        OrderId = orderId;
        CustomerId = customerId;
        TotalAmount = totalAmount;
        OldPaymentInformation = oldPaymentInformation;
        NewPaymentInformation = newPaymentInformation;
    }
}
