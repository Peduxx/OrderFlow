namespace OrderFlow.Api.Http.Request;

public record UpdatePaymentStatusRequest
{
    [BsonRepresentation(BsonType.ObjectId)]
    public required string OrderId { get; set; }
    public required OrderStatus OrderStatus { get; set; }
    public string? Message { get; set; }
}

