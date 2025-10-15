using Generita.Application.Common.Dtos.ApiDtos;

namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class CreatePaymentResponse
    {
        public CreatePaymentDate data { get; set; }
        public ICollection<string> errors { get; set; }
    }
}
