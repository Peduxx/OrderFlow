namespace OrderFlow.Application.DTOs.Response;

public sealed class UpdateShippingInformationResponse : BaseResponse
{
    public string OrderId { get; }

    public UpdateShippingInformationResponse() { }

    private UpdateShippingInformationResponse(ObjectId orderId)
    {
        OrderId = orderId.ToString();
    }

    public static UpdateShippingInformationResponse Success(ObjectId orderId)
    {
        return new UpdateShippingInformationResponse(orderId);
    }

    public static UpdateShippingInformationResponse Failure(string error)
    {
        return BaseResponse.Failure<UpdateShippingInformationResponse>(error);
    }

    public static UpdateShippingInformationResponse Failure(IEnumerable<string> errors)
    {
        return BaseResponse.Failure<UpdateShippingInformationResponse>(errors);
    }
}
