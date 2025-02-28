namespace OrderFlow.Application.Commands.Handlers;

public sealed class UpdateShippingInformationCommandHandler : IRequestHandler<UpdateShippingInformationCommand, UpdateShippingInformationResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IValidator<UpdateShippingInformationCommand> _validator;

    public UpdateShippingInformationCommandHandler(IOrderRepository orderRepository, IMapper mapper, IMediator mediator, IValidator<UpdateShippingInformationCommand> validator)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _mediator = mediator;
        _validator = validator;
    }

    public async Task<UpdateShippingInformationResponse> Handle(UpdateShippingInformationCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return UpdateShippingInformationResponse.Failure(validationResult.Errors.Select(e => e.ErrorMessage));

        try
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId) ?? throw new ApplicationException("Order does not exists.");

            var newShippingAddress = _mapper.Map<ShippingAddress>(request);

            order.UpdateShippingAddress(newShippingAddress);

            await _orderRepository.UpdateAsync(order);

            foreach (var domainEvent in order.DomainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }

            return UpdateShippingInformationResponse.Success(order.Id);
        }
        catch (ApplicationException ex)
        {
            return UpdateShippingInformationResponse.Failure(ex.Message);
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
