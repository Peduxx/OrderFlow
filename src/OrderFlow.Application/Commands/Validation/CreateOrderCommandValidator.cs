namespace OrderFlow.Application.Commands.Validation;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEqual(ObjectId.Empty)
            .WithMessage("CustomerID cannot be empty.");

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required.");

        RuleFor(x => x.CustomerEmail)
            .NotEmpty()
            .WithMessage("Customer email is required.")
            .EmailAddress()
            .WithMessage("A valid email is required.");

        RuleFor(x => x.OrderItems)
            .NotEmpty()
            .WithMessage("The order must have at least one item.");

        RuleFor(x => x.TotalAmount)
            .GreaterThan(0)
            .WithMessage("Total Amount must be greater than zero.");

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

        RuleFor(x => x.Street)
            .NotEmpty()
            .WithMessage("Street is required.");

        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("Number is required.");

        RuleFor(x => x.Neighborhood)
            .NotEmpty()
            .WithMessage("Neighborhood is required.");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("City is required.");

        RuleFor(x => x.State)
            .NotEmpty()
            .WithMessage("State is required.");

        RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage("Country is required.");

        RuleFor(x => x.ZipCode)
            .NotEmpty()
            .WithMessage("ZipCode is required.")
            .Matches(@"^\d{5}-\d{3}$")
            .WithMessage("Invalid zipcode format. Use format: 12345-678");
    }
}
