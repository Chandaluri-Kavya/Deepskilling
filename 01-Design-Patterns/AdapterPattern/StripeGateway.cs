public class StripeGateway
{
    public void Charge(double amount)
    {
        Console.WriteLine($"Paid ₹{amount} using Stripe.");
    }
}