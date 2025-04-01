
using JobEntryy.Application.Abstracts;
using Stripe;

namespace JobEntryy.Infrastructure.Services.Payment;

public class StripePaymentService : IPaymentService
{

    private readonly string apiKey;

    public StripePaymentService(string apiKey)
    {
        this.apiKey = apiKey;
        StripeConfiguration.ApiKey = apiKey;
    }

    public async Task<string> CreatePaymentAsync(decimal amount, string currency, string description, string returnUrl, string cancelUrl)
    {
        var options = new PaymentIntentCreateOptions
        {
            Amount = (long)(amount * 100), // Stripe sentlər (cents) ilə işləyir
            Currency = currency,
            Description = description,
            PaymentMethodTypes = new List<string> { "card" }
        };

        var service = new PaymentIntentService();
        var paymentIntent = await service.CreateAsync(options);
        return paymentIntent.ClientSecret;
    }

    public async Task<bool> VerifyPaymentAsync(string paymentId)
    {
        var service = new PaymentIntentService();
        var paymentIntent = await service.GetAsync(paymentId);
        return paymentIntent.Status == "succeeded";
    }

    public async Task<string> GetPaymentStatusAsync(string paymentId)
    {
        var service = new PaymentIntentService();
        var paymentIntent = await service.GetAsync(paymentId);
        return paymentIntent.Status;
    }

    public async Task<bool> CancelPaymentAsync(string paymentId)
    {
        var service = new PaymentIntentService();
        var paymentIntent = await service.CancelAsync(paymentId);
        return paymentIntent.Status == "canceled";
    }

    public async Task<bool> RefundPaymentAsync(string paymentId, decimal amount)
    {
        var options = new RefundCreateOptions
        {
            PaymentIntent = paymentId,
            Amount = (long)(amount * 100)
        };

        var service = new RefundService();
        var refund = await service.CreateAsync(options);
        return refund.Status == "succeeded";
    }
}
