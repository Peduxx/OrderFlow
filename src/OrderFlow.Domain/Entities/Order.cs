namespace OrderFlow.Domain.Entities;

public sealed class Order : AggregateRoot
{
    public ObjectId CustomerId { get; private set; }
    public string CustomerName { get; private set; }
    public string CustomerEmail { get; private set; }
    public decimal TotalAmount { get; private set; }
    public List<OrderItem> OrderItems { get; private set; } = [];
    public OrderStatus Status { get; private set; }
    public PaymentInformation PaymentInformation { get; private set; }
    public ShippingAddress ShippingAddress { get; private set; }

    private Order() { }

    public static Order Create(
        ObjectId customerId,
        string customerName,
        string customerEmail,
        List<OrderItem> orderItems,
        decimal totalAmount,
        ShippingAddress shippingAddress,
        PaymentInformation paymentInformation
        )
    {
        var order = new Order()
        {
            Id = ObjectId.GenerateNewId(),
            CustomerId = customerId,
            CustomerName = customerName,
            CustomerEmail = customerEmail,
            OrderItems = orderItems ?? [],
            TotalAmount = totalAmount,
            Status = OrderStatus.Processing,
            ShippingAddress = shippingAddress,
            PaymentInformation = paymentInformation
        };

        order.AddDomainEvent(new OrderCreatedEvent(order.Id, order.CustomerId, order.CustomerName, order.CustomerEmail, order.TotalAmount, order.Status, order.ShippingAddress, order.PaymentInformation));

        return order;
    }

    public void SetPaymentStatus(OrderStatus status, string? message = "Payment failed.")
    {
        switch (status)
        {
            case OrderStatus.Paid:
                PaymentSucceeded();
                break;
            case OrderStatus.PendingPayment:
                PaymentFailed(message);
                break;
            default:
                throw new DomainException("Cannot update payment status.");
        }
    }

    public void UpdatePaymentInformation(PaymentInformation newPaymentInformation)
    {
        ValidatePaymentInformationUpdate();

        var oldPaymentInfo = PaymentInformation;
        PaymentInformation = newPaymentInformation;

        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new PaymentInformationUpdatedEvent(Id, CustomerId, TotalAmount, oldPaymentInfo, newPaymentInformation));
    }

    public void SetShipped()
    {
        var oldStatus = Status;
        Status = OrderStatus.Shipped;

        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new OrderShippedEvent(CustomerEmail));
    }

    public void UpdateShippingAddress(ShippingAddress newAddress)
    {
        ValidateShippingAddressUpdate();

        var oldAddress = ShippingAddress;
        ShippingAddress = newAddress;

        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new ShippingAddressUpdatedEvent(Id, CustomerId, oldAddress, newAddress));
    }

    private void PaymentSucceeded()
    {
        var oldStatus = Status;
        Status = OrderStatus.Paid;

        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new PaymentSucceededEvent(Id, CustomerId, CustomerName, CustomerEmail, oldStatus, Status));
    }

    private void PaymentFailed(string reason)
    {
        var oldStatus = Status;
        Status = OrderStatus.Paid;

        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new PaymentFailedEvent(Id, CustomerId, CustomerName, CustomerEmail, oldStatus, Status, reason));
    }
    private void ValidatePaymentInformationUpdate()
    {
        if (Status != OrderStatus.Processing && Status != OrderStatus.PendingPayment)
            throw new DomainException($"Cannot update payment method for an order with {Status} status.");
    }

    private void ValidateShippingAddressUpdate()
    {
        if (Status == OrderStatus.Shipped || Status == OrderStatus.Delivered || Status == OrderStatus.Cancelled)
            throw new DomainException($"Cannot update shipping address for an order with {Status} status.");
    }
}
