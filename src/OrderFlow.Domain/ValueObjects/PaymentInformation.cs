namespace OrderFlow.Domain.ValueObjects;

public class PaymentInformation
{
    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string CardCode { get; private set; }
    public string CardExpiration { get; private set; }

    public static PaymentInformation Create(
        string cardHolderName,
        string cardNumber,
        string cardCode,
        string cardExpiration)
    {
        var paymentInformation = new PaymentInformation
        {
            CardHolderName = cardHolderName,
            CardNumber = cardNumber,
            CardCode = cardCode,
            CardExpiration = cardExpiration
        };

        return paymentInformation;
    }
}