namespace OrderFlow.Application.Events.Handlers;

internal sealed class PaymentSucceededEventHandler : INotificationHandler<PaymentSucceededEvent>
{
    public async Task Handle(PaymentSucceededEvent notification, CancellationToken cancellationToken)
    {
        try { 
        Console.WriteLine("📨 Enviando para service de shipping(Order enviada).");
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
 