using OrderFlow.Domain.Exceptions;

namespace OrderFlow.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    public async Task ProcessPayment(ObjectId orderId, ObjectId customerId, decimal totalAmount)
    {
        try
        {
            Console.WriteLine("📦 Enviando para service de pagamento.");
        }
        catch (Exception ex)
        {
            throw new PaymentFailedException(ex.Message);
        }
    }
}

