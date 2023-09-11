namespace CDR_pdf.Models
{
    public class SmsLog
    {
        public int Id { get; set; }
        public string AccessMethodIdentifier { get; set; } = string.Empty;
        public string Sender { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public DateTime Date { get; set; } 
        public TimeSpan Time { get; set; }
    }
}
