namespace OrderFlow.Domain.Interfaces
{
    public interface IPaymentService
    {
        Task ProcessPayment(ObjectId orderId, ObjectId customerId, decimal totalAmount);
    }
}