﻿using DevFreela.Core.DTO;

namespace DevFreela.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
