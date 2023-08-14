namespace CDR_pdf.Models
{
    public class UserInputModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StatementPeriodFrom { get; set; }
        public DateTime StatementPeriodTo { get; set; }
    }
}
