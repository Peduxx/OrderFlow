namespace OrderFlow.Application.Commands.Validation;

public sealed class UpdatePaymentStatusCommandValidator : AbstractValidator<UpdatePaymentStatusCommand>
{
    public UpdatePaymentStatusCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEqual(ObjectId.Empty)
            .WithMessage("CustomerID cannot be empty.");
    }
}

