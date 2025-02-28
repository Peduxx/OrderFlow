namespace OrderFlow.Domain.ValueObjects;

public class ShippingAddress
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }


    public static ShippingAddress Create(
        string street,
        string number,
        string complement,
        string neighborhood,
        string city,
        string state,
        string country,
        string zipCode)
    {
        var shippingAddress = new ShippingAddress()
        {
            Street = street,
            Number = number,
            Complement = complement,
            Neighborhood = neighborhood,
            City = city,
            State = state,
            Country = country,
            ZipCode = zipCode
        };

        return shippingAddress;
    }
}