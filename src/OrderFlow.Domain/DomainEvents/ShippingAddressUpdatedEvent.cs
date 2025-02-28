namespace OrderFlow.Domain.DomainEvents;

public record ShippingAddressUpdatedEvent : IDomainEvent
{
    public ObjectId OrderId { get; }
    public ObjectId CustomerId { get; }
    public ShippingAddress OldShippingAddress { get; }
    public ShippingAddress NewShippingAddress { get; }

    public ObjectId Id => ObjectId.GenerateNewId();
    public string Type => "ShippingAddressUpdated";
    public DateTime OccurredOn => DateTime.UtcNow;

    public ShippingAddressUpdatedEvent(ObjectId orderId, ObjectId customerId, ShippingAddress oldShippingAddress, ShippingAddress newShippingAddress)
    {
        OrderId = orderId;
        CustomerId = customerId;
        OldShippingAddress = oldShippingAddress;
        NewShippingAddress = newShippingAddress;
    }
}
