using Microsoft.AspNetCore.Mvc;
using SecurePaymentIntegration.Models;
using SecurePaymentIntegration.Services;

namespace SecurePaymentIntegration.Controllers
{
    public class PaymentController : Controller
    {
        private readonly StripePaymentService _paymentService;

        public PaymentController(
            StripePaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pay(
            PaymentViewModel model)
        {
            string successUrl =
                Url.Action(
                    "Success",
                    "Payment",
                    null,
                    Request.Scheme)!;

            string cancelUrl =
                Url.Action(
                    "Cancel",
                    "Payment",
                    null,
                    Request.Scheme)!;

            var paymentUrl =
                _paymentService.CreateCheckoutSession(
                    model.Amount,
                    successUrl,
                    cancelUrl);

            return Redirect(paymentUrl);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }
    }
}
