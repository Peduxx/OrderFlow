namespace OrderFlow.Infrastructure.Data.Repositories;

public partial class OrderRepository
{
    public async Task SaveAsync(Order order)
    {
        await _collection.InsertOneAsync(order);
    }

    public async Task UpdateAsync(Order order)
    {
        var filter = Builders<Order>.Filter.Eq(o => o.Id, order.Id);
        await _collection.ReplaceOneAsync(filter, order);
    }
}
