namespace OrderFlow.Domain.Primitives;

public interface IDomainEvent : INotification
{
    public ObjectId Id { get; }
    public string Type { get; }
    DateTime OccurredOn { get; }
}
