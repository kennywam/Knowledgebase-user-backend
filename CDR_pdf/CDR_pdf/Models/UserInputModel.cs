namespace CDR_pdf.Models
{
    public class UserInputModel
    {
        internal List<DailyDataCdr> dailyDataCDRs;

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StatementPeriodFrom { get; set; }
        public DateTime StatementPeriodTo { get; set; }
        public string SelectedService { get; set; }
        public string DataForPDF { get; set; }
        public List<CallLog> CallLogs { get; internal set; }
        public List<SmsLog> SmsLogs { get; internal set; }
    }
}
