namespace OrderFlow.Application.Commands.Handlers;

public sealed class UpdatePaymentInformationCommandHandler : IRequestHandler<UpdatePaymentInformationCommand, UpdatePaymentInformationResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IValidator<UpdatePaymentInformationCommand> _validator;

    public UpdatePaymentInformationCommandHandler(IOrderRepository orderRepository, IMapper mapper, IMediator mediator, IValidator<UpdatePaymentInformationCommand> validator)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _mediator = mediator;
        _validator = validator;
    }

    public async Task<UpdatePaymentInformationResponse> Handle(UpdatePaymentInformationCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return UpdatePaymentInformationResponse.Failure(validationResult.Errors.Select(e => e.ErrorMessage));

        try
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId) ?? throw new ApplicationException("Order does not exists.");

            var newPaymentInformation = _mapper.Map<PaymentInformation>(request);

            order.UpdatePaymentInformation(newPaymentInformation);

            await _orderRepository.UpdateAsync(order);

            foreach (var domainEvent in order.DomainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }

            return UpdatePaymentInformationResponse.Success(order.Id);
        }
        catch (ApplicationException ex)
        {
            return UpdatePaymentInformationResponse.Failure(ex.Message);
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

