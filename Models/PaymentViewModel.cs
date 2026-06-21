namespace SecurePaymentIntegration.Models
{
    public class PaymentViewModel
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; } = "usd";
    }
}
