namespace OrderFlow.Api.Http.Request;

public record UpdateShippingStatusRequest
{
    [BsonRepresentation(BsonType.ObjectId)]
    public required string OrderId { get; set; }
}

