namespace OrderFlow.Application.Commands.Validation;

public sealed class UpdatePaymentInformationCommandValidator : AbstractValidator<UpdatePaymentInformationCommand>
{
    public UpdatePaymentInformationCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEqual(ObjectId.Empty)
            .WithMessage("CustomerID cannot be empty.");

        RuleFor(x => x.CardHolderName)
            .NotEmpty()
            .WithMessage("Card holder name cannot be empty.");

        RuleFor(x => x.CardNumber)
            .NotEmpty()
            .WithMessage("Card number is required.")
            .Matches(@"^\d{13,19}$")
            .WithMessage("Invalid card number.");

        RuleFor(x => x.CardCode)
            .NotEmpty()
            .WithMessage("Card security code is required.")
            .Matches(@"^\d{3,4}$")
            .WithMessage("Invalid security code.");

        RuleFor(x => x.CardExpiration)
            .NotEmpty()
            .WithMessage("Card expiration date is required.")
            .Matches(@"^(0[1-9]|1[0-2])\/\d{2}$")
            .WithMessage("Invalid expiration date.");
    }
}
