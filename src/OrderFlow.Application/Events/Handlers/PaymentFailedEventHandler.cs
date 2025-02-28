namespace OrderFlow.Application.Events.Handlers;

internal sealed class PaymentFailedEventHandler : INotificationHandler<PaymentFailedEvent>
{
    public async Task Handle(PaymentFailedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("📨 Enviando para service de email(para de Order falhou).");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
