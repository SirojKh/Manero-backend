namespace Manero_Backend.Models.Dtos.PaymentDetail
{
    public class PaymentDetailDto
    {
        public Guid Id { get; set; }
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public string ExpDate { get; set; } = null!;

    }
}
