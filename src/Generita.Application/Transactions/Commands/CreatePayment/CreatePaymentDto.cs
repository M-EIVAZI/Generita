namespace Generita.Application.Transactions.Commands.CreatePayment
{
    public class CreatePaymentDto
    {
        public Guid planId { get; set; }
        public Guid userId { get; set; }

    }
}
