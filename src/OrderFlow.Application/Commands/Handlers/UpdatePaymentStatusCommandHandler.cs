namespace OrderFlow.Application.Commands.Handlers;

public sealed class UpdatePaymentStatusCommandHandler : IRequestHandler<UpdatePaymentStatusCommand, UpdatePaymentStatusResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;
    private readonly IValidator<UpdatePaymentStatusCommand> _validator;

    public UpdatePaymentStatusCommandHandler(IOrderRepository orderRepository, IMediator mediator, IValidator<UpdatePaymentStatusCommand> validator)
    {
        _orderRepository = orderRepository;
        _mediator = mediator;
        _validator = validator;
    }

    public async Task<UpdatePaymentStatusResponse> Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return UpdatePaymentStatusResponse.Failure(validationResult.Errors.Select(e => e.ErrorMessage));

        try
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId) ?? throw new ApplicationException("Order not found.");

            order.SetPaymentStatus(request.OrderStatus, request.Message);

            await _orderRepository.UpdateAsync(order);

            foreach (var domainEvents in order.DomainEvents)
            {
                await _mediator.Publish(domainEvents, cancellationToken);
            }

            return UpdatePaymentStatusResponse.Success(order.Id, order.Status);
        }
        catch (ApplicationException ex)
        {
            return UpdatePaymentStatusResponse.Failure(ex.Message);
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
