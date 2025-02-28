namespace OrderFlow.Application.DTOs.Response;

public sealed class CreateOrderResponse : BaseResponse
{
    public string OrderId { get; }

    public CreateOrderResponse() { }

    private CreateOrderResponse(ObjectId orderId) : base()
    {
        OrderId = orderId.ToString();
    }

    public static CreateOrderResponse Success(ObjectId orderId)
    {
        return new CreateOrderResponse(orderId);
    }

    public static CreateOrderResponse Failure(string error)
    {
        return BaseResponse.Failure<CreateOrderResponse>(error);
    }

    public static CreateOrderResponse Failure(IEnumerable<string> errors)
    {
        return BaseResponse.Failure<CreateOrderResponse>(errors);
    }
}
