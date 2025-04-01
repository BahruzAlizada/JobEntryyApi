

namespace JobEntryy.Application.Abstracts
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentAsync(decimal amount, string currency, string description, string returnUrl, string cancelUrl);
        Task<bool> VerifyPaymentAsync(string paymentId);
        Task<bool> CancelPaymentAsync(string paymentId);
        Task<bool> RefundPaymentAsync(string paymentId, decimal amount);
        Task<string> GetPaymentStatusAsync(string paymentId);
    }
}
