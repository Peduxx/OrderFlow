namespace OrderFlow.Domain.Enums
{
    public enum OrderStatus
    {
        Processing,
        PendingPayment,
        Paid,
        Shipped,
        Delivered,
        Cancelled
    }
}