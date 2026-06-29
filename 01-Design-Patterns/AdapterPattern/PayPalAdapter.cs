public class PayPalAdapter : PaymentProcessor
{
    private PayPalGateway paypal = new PayPalGateway();

    public void ProcessPayment(double amount)
    {
        paypal.MakePayment(amount);
    }
}