namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class CreatePaymentRequest
    {
        public string merchant_id { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        public string callback_url { get; set; }
    }
}
