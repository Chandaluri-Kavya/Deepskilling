PaymentProcessor paypal = new PayPalAdapter();
PaymentProcessor stripe = new StripeAdapter();

paypal.ProcessPayment(5000);
stripe.ProcessPayment(7500);