namespace OrderFlow.Application.Commands;

public record UpdatePaymentInformationCommand : IRequest<UpdatePaymentInformationResponse>
{
    public ObjectId OrderId { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string CardCode { get; set; }
    public string CardExpiration { get; set; }
}

