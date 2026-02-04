
public class PaymentHandler
{
    private readonly ICreditCardPayment _cardPayment;
    private readonly IPayPalPayment _payPalPayment;
    private readonly ICryptoPayment _cryptoPayment;

    public PaymentHandler(
        ICreditCardPayment cardPayment,
        IPayPalPayment payPalPayment,
        ICryptoPayment cryptoPayment)
    {
        _cardPayment = cardPayment;
        _payPalPayment = payPalPayment;
        _cryptoPayment = cryptoPayment;
    }

    public void PayByCard(decimal amount)
    {
        _cardPayment.Pay(amount);
    }

    public void PayByPayPal(decimal amount)
    {
        _payPalPayment.Pay(amount);
    }

    public void PayByCrypto(decimal amount)
    {
        _cryptoPayment.Pay(amount);
    }
}
