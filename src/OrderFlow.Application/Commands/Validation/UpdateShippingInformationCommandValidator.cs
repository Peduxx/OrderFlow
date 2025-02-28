namespace OrderFlow.Application.Commands.Validation;

public sealed class UpdateShippingInformationCommandValidator : AbstractValidator<UpdateShippingInformationCommand>
{
    public UpdateShippingInformationCommandValidator()
    {
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
