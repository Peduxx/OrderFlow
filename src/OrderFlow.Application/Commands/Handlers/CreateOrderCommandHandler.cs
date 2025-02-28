namespace OrderFlow.Application.Commands.Handlers;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateOrderCommand> _validator;

    public CreateOrderCommandHandler(
        IMediator mediator,
        IMapper mapper,
        IOrderRepository orderRepository,
        IValidator<CreateOrderCommand> validator)
    {
        _mediator = mediator;
        _mapper = mapper;
        _orderRepository = orderRepository;
        _validator = validator;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return CreateOrderResponse.Failure(validationResult.Errors.Select(e => e.ErrorMessage));

        try
        {
            var order = _mapper.Map<Order>(request);
            await _orderRepository.SaveAsync(order);

            foreach (var domainEvent in order.DomainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }

            return CreateOrderResponse.Success(order.Id);
        }
        catch (ApplicationException ex)
        {
            return CreateOrderResponse.Failure(ex.Message);
        }
        catch (DomainException ex)
        {
            throw new DomainException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}