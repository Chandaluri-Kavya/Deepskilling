public class StripeAdapter : PaymentProcessor
{
    private StripeGateway stripe = new StripeGateway();

    public void ProcessPayment(double amount)
    {
        stripe.Charge(amount);
    }
}