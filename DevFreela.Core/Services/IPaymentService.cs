﻿using DevFreela.Core.DTO;

namespace DevFreela.Core.Services
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
