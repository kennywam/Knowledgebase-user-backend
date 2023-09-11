namespace CDR_pdf.Models;
public class CallLog
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Caller { get; set; } = string.Empty;
    public string Called { get; set; } = string.Empty;

 
}
