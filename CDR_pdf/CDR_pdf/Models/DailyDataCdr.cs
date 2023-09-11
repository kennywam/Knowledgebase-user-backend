namespace CDR_pdf.Models
{
    public class DailyDataCdr
    {
        public int Id { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public decimal VolumeMb { get; set; }
    }
}
