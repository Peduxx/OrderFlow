namespace OrderFlow.Infrastructure.Data.Repositories;

public partial class OrderRepository
{
    public async Task<Order> GetByIdAsync(ObjectId id)
    {
        return await _collection
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order>> GetAllByCostumerAsync(ObjectId customerId)
    {
        return await _collection
            .Find(x => x.CustomerId == customerId)
            .ToListAsync();
    }
}

