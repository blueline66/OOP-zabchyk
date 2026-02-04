using System;

class Program
{
    static void Main(string[] args)
    {
        ICreditCardPayment card = new CreditCardGateway();
        IPayPalPayment paypal = new PayPalService();
        ICryptoPayment crypto = new CryptoExchange();

        PaymentHandler handler = new PaymentHandler(card, paypal, crypto);

        handler.PayByCard(1000);
        handler.PayByPayPal(500);
        handler.PayByCrypto(0.02m);
    }
}