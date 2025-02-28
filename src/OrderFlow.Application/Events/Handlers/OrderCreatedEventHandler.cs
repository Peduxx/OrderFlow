namespace OrderFlow.Application.Events.Handlers;

internal sealed class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly IPaymentService _paymentService;

    public OrderCreatedEventHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("📨 Enviando para service de email(Order criada).");
            await _paymentService.ProcessPayment(notification.OrderId, notification.CustomerId, notification.TotalAmount);
        }
        catch (PaymentFailedException ex)
        {
            throw new PaymentFailedException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
