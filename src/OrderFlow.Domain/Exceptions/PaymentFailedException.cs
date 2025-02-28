namespace OrderFlow.Domain.Exceptions
{
    public class PaymentFailedException(string message) : Exception(message)
    {
    }
}