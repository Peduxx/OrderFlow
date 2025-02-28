namespace OrderFlow.Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(ObjectId id);
    Task<IEnumerable<Order>> GetAllByCostumerAsync(ObjectId customerId);
    Task SaveAsync(Order order);
    Task UpdateAsync(Order order);
}
