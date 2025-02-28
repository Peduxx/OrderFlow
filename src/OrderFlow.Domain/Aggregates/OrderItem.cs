namespace OrderFlow.Domain.Aggregates;

public class OrderItem
{
    public ObjectId Id { get; private set; }

    public OrderItem()
    {
    }

    public OrderItem(ObjectId id)
    {
        Id = id;
    }
}
