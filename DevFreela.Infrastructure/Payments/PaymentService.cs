using DevFreela.Core.DTO;
using DevFreela.Core.Services;
using System.Net.Http;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            //Logic for payment gateway

            return Task.FromResult(true);
        }
    }
}
