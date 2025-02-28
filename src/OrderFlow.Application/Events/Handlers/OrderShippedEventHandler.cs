namespace OrderFlow.Application.Events.Handlers;

internal sealed class OrderShippedEventHandler : INotificationHandler<OrderShippedEvent>
{
    public async Task Handle(OrderShippedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("📨 Enviando para service de email(Order enviada).");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
