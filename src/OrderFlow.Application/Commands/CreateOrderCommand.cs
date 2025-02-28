namespace OrderFlow.Application.Commands;

public record CreateOrderCommand : IRequest<CreateOrderResponse>
{
    public ObjectId CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public List<ObjectId> OrderItems { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string CardCode { get; set; }
    public string CardExpiration { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}
