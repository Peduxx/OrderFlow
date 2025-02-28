namespace OrderFlow.Application.DTOs.Response;

public sealed class UpdatePaymentInformationResponse : BaseResponse
{
    public string OrderId { get; }

    public UpdatePaymentInformationResponse() { }

    private UpdatePaymentInformationResponse(ObjectId orderId)
    {
        OrderId = orderId.ToString();
    }

    public static UpdatePaymentInformationResponse Success(ObjectId orderId)
    {
        return new UpdatePaymentInformationResponse(orderId);
    }

    public static UpdatePaymentInformationResponse Failure(string error)
    {
        return BaseResponse.Failure<UpdatePaymentInformationResponse>(error);
    }

    public static UpdatePaymentInformationResponse Failure(IEnumerable<string> errors)
    {
        return BaseResponse.Failure<UpdatePaymentInformationResponse>(errors);
    }
}

