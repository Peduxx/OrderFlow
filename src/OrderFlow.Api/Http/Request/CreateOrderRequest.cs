namespace OrderFlow.Api.Http.Request;

public record CreateOrderRequest
{
    [BsonRepresentation(BsonType.ObjectId)]
    public required string CustomerId { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public required string CustomerName { get; set; }
    public required string CustomerEmail { get; set; }
    public required List<string> OrderItems { get; set; } = [];
    public required decimal TotalAmount { get; set; }
    public required string CardHolderName { get; set; }
    public required string CardNumber { get; set; }
    public required string CardCode { get; set; }
    public required string CardExpiration { get; set; }
    public required string Street { get; set; }
    public required string Number { get; set; }
    public required string Complement { get; set; }
    public required string Neighborhood { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string ZipCode { get; set; }
}
