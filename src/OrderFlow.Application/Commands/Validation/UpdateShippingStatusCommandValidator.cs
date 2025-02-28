namespace OrderFlow.Application.Commands.Validation;

public sealed class UpdateShippingStatusCommandValidator : AbstractValidator<UpdateShippingStatusCommand>
{
    public UpdateShippingStatusCommandValidator()
    {
        RuleFor(x => x.OrderId)
    .NotEqual(ObjectId.Empty)
    .WithMessage("CustomerID cannot be empty.");
    }
}
