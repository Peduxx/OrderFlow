namespace OrderFlow.Application.DTOs.Response;

public sealed class UpdatePaymentStatusResponse : BaseResponse
{
    public string OrderId { get; }
    public OrderStatus OrderStatus { get; }

    public UpdatePaymentStatusResponse() { }

    private UpdatePaymentStatusResponse(ObjectId orderId, OrderStatus orderStatus)
    {
        OrderId = orderId.ToString();
        OrderStatus = orderStatus;
    }

    public static UpdatePaymentStatusResponse Success(ObjectId orderId, OrderStatus status)
    {
        return new UpdatePaymentStatusResponse(orderId, status);
    }

    public static UpdatePaymentStatusResponse Failure(string error)
    {
        return BaseResponse.Failure<UpdatePaymentStatusResponse>(error);
    }

    public static UpdatePaymentStatusResponse Failure(IEnumerable<string> errors)
    {
        return BaseResponse.Failure<UpdatePaymentStatusResponse>(errors);
    }
}