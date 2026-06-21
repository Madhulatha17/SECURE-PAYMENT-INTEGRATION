using Stripe.Checkout;

namespace SecurePaymentIntegration.Services
{
    public class StripePaymentService
    {
        public string CreateCheckoutSession(
            decimal amount,
            string successUrl,
            string cancelUrl)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes =
                    new List<string> { "card" },

                LineItems =
                    new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            PriceData =
                                new SessionLineItemPriceDataOptions
                                {
                                    Currency = "usd",

                                    UnitAmount =
                                        (long)(amount * 100),

                                    ProductData =
                                        new SessionLineItemPriceDataProductDataOptions
                                        {
                                            Name = "Order Payment"
                                        }
                                },

                            Quantity = 1
                        }
                    },

                Mode = "payment",

                SuccessUrl = successUrl,

                CancelUrl = cancelUrl
            };

            var service = new SessionService();

            Session session =
                service.Create(options);

            return session.Url;
        }
    }
}
