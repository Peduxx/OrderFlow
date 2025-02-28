
namespace OrderFlow.Domain.DomainEvents;

public record OrderShippedEvent : IDomainEvent
{
    public string CustomerEmail { get; }

    public ObjectId Id => ObjectId.GenerateNewId();
    public string Type => "OrderShipped";
    public DateTime OccurredOn => DateTime.UtcNow;

    public OrderShippedEvent(string customerEmail)
    {
        CustomerEmail = customerEmail;
    }
}

