using Polly.Caching;

namespace OrderFlow.Api.Controllers;

[ApiVersion("1.0")]
[Route("api/v1/[controller]")]
[ApiController]
[Produces("application/vnd.meusistema.v1+json")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OrderController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateOrderResponse), 200)]
    [EndpointSummary("Create new order.")]
    [EndpointDescription("In this endpoint you can create a new order.")]
    public async Task<IActionResult> CreateOrder([FromBody]CreateOrderRequest request)
    {
        var command = _mapper.Map<CreateOrderCommand>(request);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(UpdatePaymentInformationResponse), 200)]
    [EndpointSummary("Update payment information.")]
    [EndpointDescription("In this endpoint you can update the payment information of one order.")]
    public async Task<IActionResult> UpdatePaymentInformation([FromBody]UpdatePaymentInformationRequest request)
    {
        var command = _mapper.Map<UpdatePaymentInformationCommand>(request);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(UpdateShippingInformationResponse), 200)]
    [EndpointSummary("Update shipping information.")]
    [EndpointDescription("In this endpoint you can update the shipping information of one order.")]
    public async Task<IActionResult> UpdateShippingInformation([FromBody] UpdateShippingInformationRequest request)
    {
        var command = _mapper.Map<UpdateShippingInformationCommand>(request);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(UpdatePaymentStatusResponse), 200)]
    [EndpointSummary("Update payment status.")]
    [EndpointDescription("This endpoint notify the system about the payment status of an order.")]
    public async Task<IActionResult> UpdatePaymentStatus([FromBody] UpdatePaymentStatusRequest request)
    {
        var command = _mapper.Map<UpdatePaymentStatusCommand>(request);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(UpdateShippingStatusResponse), 200)]
    [EndpointSummary("Update shipping status.")]
    [EndpointDescription("This endpoint notify the system about the shipping status of an order.")]
    public async Task<IActionResult> UpdateShippingStatus([FromBody] UpdateShippingStatusRequest request)
    {
        var command = _mapper.Map<UpdateShippingStatusCommand>(request);

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
