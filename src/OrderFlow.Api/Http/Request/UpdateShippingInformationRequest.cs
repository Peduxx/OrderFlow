namespace OrderFlow.Api.Http.Request;

public record UpdateShippingInformationRequest
{
    [BsonRepresentation(BsonType.ObjectId)]
    public required string OrderId { get; set; }
    public required string Street { get; set; }
    public required string Number { get; set; }
    public required string Complement { get; set; }
    public required string Neighborhood { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string ZipCode { get; set; }
}

