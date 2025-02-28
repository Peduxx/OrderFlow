namespace OrderFlow.Application.Commands.Handlers;

public sealed class UpdateShippingStatusCommandHandler : IRequestHandler<UpdateShippingStatusCommand, UpdateShippingStatusResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;
    private readonly IValidator<UpdateShippingStatusCommand> _validator;

    public UpdateShippingStatusCommandHandler(IOrderRepository orderRepository, IMediator mediator, IValidator<UpdateShippingStatusCommand> validator)
    {
        _orderRepository = orderRepository;
        _mediator = mediator;
        _validator = validator;
    }

    public async Task<UpdateShippingStatusResponse> Handle(UpdateShippingStatusCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return UpdateShippingStatusResponse.Failure(validationResult.Errors.Select(e => e.ErrorMessage));

        try
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId) ?? throw new ApplicationException("Order not found.");

            order.SetShipped();

            await _orderRepository.UpdateAsync(order);

            foreach (var domainEvents in order.DomainEvents)
            {
                await _mediator.Publish(domainEvents, cancellationToken);
            }

            return new UpdateShippingStatusResponse(order.Id, order.Status);
        }
        catch (ApplicationException ex)
        {
            return UpdateShippingStatusResponse.Failure(ex.Message);
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

