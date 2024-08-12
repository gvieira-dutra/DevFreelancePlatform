namespace DevFreela.Core.DTO
{
    public class PaymentInfoDTO(int id, string ccNumber, string cvv, string expiryDate, string fullName)
    {
        public int Id { get; set; } = id;
        public string CcNumber { get; set; } = ccNumber;
        public string Cvv { get; set; } = cvv;
        public string ExpiryDate { get; set; } = expiryDate;
        public string FullName { get; set; } = fullName;
    }
}
