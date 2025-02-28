namespace OrderFlow.Application.Events.Handlers;

internal sealed class PaymentInformationUpdatedEventHandler : INotificationHandler<PaymentInformationUpdatedEvent>
{
    private readonly IPaymentService _paymentService;

    public PaymentInformationUpdatedEventHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public async Task Handle(PaymentInformationUpdatedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("📨 Enviando para service de email(informacoes de pagamento de Order atualizadas).");
            await _paymentService.ProcessPayment(notification.OrderId, notification.CustomerId, notification.TotalAmount);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

