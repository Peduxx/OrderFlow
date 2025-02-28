namespace OrderFlow.Application.DTOs.Response;

public sealed class UpdateShippingStatusResponse : BaseResponse
{
    public string OrderId { get; }
    public OrderStatus OrderStatus { get; }

    public UpdateShippingStatusResponse() { }

    public UpdateShippingStatusResponse(ObjectId orderId, OrderStatus orderStatus)
    {
        OrderId = orderId.ToString();
        OrderStatus = orderStatus;
    }

    public static UpdateShippingStatusResponse Success(ObjectId orderId, OrderStatus status)
    {
        return new UpdateShippingStatusResponse(orderId, status);
    }

    public static UpdateShippingStatusResponse Failure(string error)
    {
        return BaseResponse.Failure<UpdateShippingStatusResponse>(error);
    }

    public static UpdateShippingStatusResponse Failure(IEnumerable<string> errors)
    {
        return BaseResponse.Failure<UpdateShippingStatusResponse>(errors);
    }
}
