namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class ZarinPalData
    {
        public int code { get; set; }
        public int ref_id { get; set; }
        public string message { get; set; } = string.Empty;
        public string card_pan { get; set; }
        public string card_hash { get; set; }
        public string fee_type { get; set; }
        public int fee { get; set; }
    }
}
