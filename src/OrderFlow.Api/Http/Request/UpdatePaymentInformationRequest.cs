namespace OrderFlow.Api.Http.Request;

public record UpdatePaymentInformationRequest
{
    [BsonRepresentation(BsonType.ObjectId)]
    public required string OrderId { get; set; }
    public required string CardHolderName { get; set; }
    public required string CardNumber { get; set; }
    public required string CardCode { get; set; }
    public required string CardExpiration { get; set; }
}
