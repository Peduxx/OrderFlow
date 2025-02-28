namespace OrderFlow.Infrastructure.Data.Repositories;

public partial class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> _collection;

    public OrderRepository(IMongoCollection<Order> collection)
    {
        _collection = collection;
    }
}