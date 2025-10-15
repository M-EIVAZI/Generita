namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class VerifyPaymentResonse
    {
        public ZarinPalData? data { get; set; }
        public List<string>? errors { get; set; }

    }
}
