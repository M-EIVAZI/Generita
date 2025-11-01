public class PaymentError
{
    public string Message { get; set; }
    public int Code { get; set; }
    public ICollection<string> Validations { get; set; }
}