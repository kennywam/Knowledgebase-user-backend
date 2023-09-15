using CDR_pdf.Data;
using CDR_pdf.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CDR_pdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {


            var CallLogs = _dbContext.CallLogs.ToList();
            var SmsLogs = _dbContext.SmsLogs.ToList();
            var dailyDataCDRs = _dbContext.DailyDataCdrs.ToList();

            return View(new UserInputModel()
            {
                CallLogs = CallLogs,
                SmsLogs = SmsLogs,
                dailyDataCDRs = dailyDataCDRs
            });
        }

        [HttpPost]
        public IActionResult PDF(UserInputModel userInput)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                //Event handler
                writer.PageEvent = new PdfPageEventhandler();
                document.Open();

                Paragraph SpaceParagraph = new Paragraph(" ");
                SpaceParagraph.SpacingAfter = 35;
                document.Add(SpaceParagraph);

                Paragraph userParagraph = new Paragraph(
                           $"Email: {userInput.Email}\n" +
                           $"Phone: {userInput.PhoneNumber}\n" +
                           $"CDR type: {userInput.SelectedService}\n" +
                           $"Statement Period From: {userInput.StatementPeriodFrom.ToShortDateString()}\n" +
                           $"Statement Period To: {userInput.StatementPeriodTo.ToShortDateString()}");
                userParagraph.SpacingAfter = 20;
                float indentationLeftValue = 60f;
                userParagraph.IndentationLeft = indentationLeftValue;
                document.Add(userParagraph);

                if (userInput.SelectedService == "CallLogs")
                {
                    PdfPTable table = new PdfPTable(7);

                    PdfPCell cell1 = new PdfPCell(new Phrase("Number", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell1.BorderWidth = 1f;
                    cell1.BorderWidthTop = 1f;
                    cell1.BorderWidthLeft = 1f;
                    cell1.BorderWidthRight = 1f;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell1);


                    PdfPCell cell2 = new PdfPCell(new Phrase("Caller", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell2.BorderWidth = 1f;
                    cell2.BorderWidthTop = 1f;
                    cell2.BorderWidthLeft = 1f;
                    cell2.BorderWidthRight = 1f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell2);


                    PdfPCell cell3 = new PdfPCell(new Phrase("Called", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell3.BorderWidth = 1f;
                    cell3.BorderWidthTop = 1f;
                    cell3.BorderWidthLeft = 1f;
                    cell3.BorderWidthRight = 1f;
                    cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell3.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell3);

                    PdfPCell cell4 = new PdfPCell(new Phrase("Date", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell4.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell4.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell4.BorderWidth = 1f;
                    cell4.BorderWidthTop = 1f;
                    cell4.BorderWidthLeft = 1f;
                    cell4.BorderWidthRight = 1f;
                    cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell4.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell4);

                    PdfPCell cell5 = new PdfPCell(new Phrase("Time", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell5.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell5.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell5.BorderWidth = 1f;
                    cell5.BorderWidthTop = 1f;
                    cell5.BorderWidthLeft = 1f;
                    cell5.BorderWidthRight = 1f;
                    cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell5.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell5);

                    PdfPCell cell6 = new PdfPCell(new Phrase("Duration in sec", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell6.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell6.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell6.BorderWidth = 1f;
                    cell6.BorderWidthTop = 1f;
                    cell6.BorderWidthLeft = 1f;
                    cell6.BorderWidthRight = 1f;
                    cell6.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell6.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell6);

                    PdfPCell cell7 = new PdfPCell(new Phrase("Duration in Min", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell7.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell7.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell7.BorderWidth = 1f;
                    cell7.BorderWidthTop = 1f;
                    cell7.BorderWidthLeft = 1f;
                    cell7.BorderWidthRight = 1f;
                    cell7.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell7.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell7);

                    for (int i = 0; i < 10; i++)
                    {
                        PdfPCell cell_1 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_2 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_3 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_4 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_5 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_6 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_7 = new PdfPCell(new Phrase(" "));



                        table.AddCell(cell_1);
                        table.AddCell(cell_2);
                        table.AddCell(cell_3);
                        table.AddCell(cell_4);
                        table.AddCell(cell_5);
                        table.AddCell(cell_6);
                        table.AddCell(cell_7);
                    }
                    document.Add(table);


                }
                else if (userInput.SelectedService == "SMSLogs")
                {
                    PdfPTable table = new PdfPTable(5);


                    PdfPCell cell1 = new PdfPCell(new Phrase("Number", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell1.BorderWidth = 1f;
                    cell1.BorderWidthTop = 1f;
                    cell1.BorderWidthLeft = 1f;
                    cell1.BorderWidthRight = 1f;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell1);


                    PdfPCell cell2 = new PdfPCell(new Phrase("Sender", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell2.BorderWidth = 1f;
                    cell2.BorderWidthTop = 1f;
                    cell2.BorderWidthLeft = 1f;
                    cell2.BorderWidthRight = 1f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell2);


                    PdfPCell cell3 = new PdfPCell(new Phrase("Receiver", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell3.BorderWidth = 1f;
                    cell3.BorderWidthTop = 1f;
                    cell3.BorderWidthLeft = 1f;
                    cell3.BorderWidthRight = 1f;
                    cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell3.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell3);

                    PdfPCell cell4 = new PdfPCell(new Phrase("Date", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell4.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell4.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell4.BorderWidth = 1f;
                    cell4.BorderWidthTop = 1f;
                    cell4.BorderWidthLeft = 1f;
                    cell4.BorderWidthRight = 1f;
                    cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell4.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell4);

                    PdfPCell cell5 = new PdfPCell(new Phrase("Time", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell5.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell5.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell5.BorderWidth = 1f;
                    cell5.BorderWidthTop = 1f;
                    cell5.BorderWidthLeft = 1f;
                    cell5.BorderWidthRight = 1f;
                    cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell5.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell5);

                    for (int i = 0; i < 10; i++)
                    {
                        PdfPCell cell_1 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_2 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_3 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_4 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_5 = new PdfPCell(new Phrase(" "));

                        table.AddCell(cell_1);
                        table.AddCell(cell_2);
                        table.AddCell(cell_3);
                        table.AddCell(cell_4);
                        table.AddCell(cell_5);
                    }
                    document.Add(table);

                }
                else if (userInput.SelectedService == "DailyDataCDRs")
                {
                    PdfPTable table = new PdfPTable(4);

                    PdfPCell cell1 = new PdfPCell(new Phrase("Number", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell1.BorderWidth = 1f;
                    cell1.BorderWidthTop = 1f;
                    cell1.BorderWidthLeft = 1f;
                    cell1.BorderWidthRight = 1f;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell1);


                    PdfPCell cell2 = new PdfPCell(new Phrase("Date", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell2.BorderWidth = 1f;
                    cell2.BorderWidthTop = 1f;
                    cell2.BorderWidthLeft = 1f;
                    cell2.BorderWidthRight = 1f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell2);


                    PdfPCell cell3 = new PdfPCell(new Phrase("Volume(KB", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell3.BorderWidth = 1f;
                    cell3.BorderWidthTop = 1f;
                    cell3.BorderWidthLeft = 1f;
                    cell3.BorderWidthRight = 1f;
                    cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell3.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell3);

                    PdfPCell cell4 = new PdfPCell(new Phrase("Volume(MB)", new Font(Font.FontFamily.HELVETICA, 10)));
                    cell4.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell4.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                    cell4.BorderWidth = 1f;
                    cell4.BorderWidthTop = 1f;
                    cell4.BorderWidthLeft = 1f;
                    cell4.BorderWidthRight = 1f;
                    cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell4.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell4);

                    for (int i = 0; i < 10; i++)
                    {
                        PdfPCell cell_1 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_2 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_3 = new PdfPCell(new Phrase(" "));
                        PdfPCell cell_4 = new PdfPCell(new Phrase(" "));


                        table.AddCell(cell_1);
                        table.AddCell(cell_2);
                        table.AddCell(cell_3);
                        table.AddCell(cell_4);

                    }
                    document.Add(table);
                }
                document.Close();
                writer.Close();

                var constant = ms.ToArray();
                return File(constant, "application/vmd", "CDR.pdf");


            }
            return View();
        }

        //custorm page event handler
        public class PdfPageEventhandler : PdfPageEventHelper
        {
            public override void OnStartPage(PdfWriter writer, iTextSharp.text.Document document)
            {
                base.OnStartPage(writer, document);

                var image = iTextSharp.text.Image.GetInstance("wwwroot/image/img.png");
                image.ScaleToFit(65, 65);
                float x = PageSize.A4.Right - (3 * document.RightMargin) - image.ScaledWidth;
                float y = PageSize.A4.Top - document.TopMargin - image.ScaledHeight;

                image.SetAbsolutePosition(x, y);
                writer.DirectContent.AddImage(image);

                BaseColor textColor = BaseColor.RED;
                Font font = new Font(Font.FontFamily.HELVETICA, 12);
                font.Color = textColor;

                ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER,
                    new Phrase("AIRTEL NETWORKS KENYA LIMITED", font),
                    document.PageSize.Width / 2, document.PageSize.Height - document.TopMargin - 35, 0);
            }
            //Fixing the footer
            // public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document document)
            // {
            //     base.OnEndPage(writer, document);

            //     var footPhrase = CreateFooterPhrase(document, "Airtel Networks Kenya Ltd. | Parkside Towers, " +
            //          "Mombasa Rd | P.O. Box 73146-00200, Nairobi, Kenya | Call Center: 100| " +
            //          "Email:\n customerservice@ke.airtel.com| Website: www.airtelkenya.com | " +
            //          "Facebook: www.facebook.com/AirtelKe | Twitter:\n twitter.com/AIRTEL_KE" +
            //          " | VAT NO.01147460 PIN-P051131780Q", new Font(Font.FontFamily.HELVETICA, 8)
            //     );

            //     ColumnText.ShowTextAligned(
            //         writer.DirectContent,
            //         Element.ALIGN_CENTER,
            //         footPhrase,
            //         document.PageSize.Width / 2,
            //         document.BottomMargin + 10, // Adjust this value for vertical position
            //         0
            //     );

            // }
            // private ColumnText CreateFooterPhrase(iTextSharp.text.Document document, string text, Font font)
            // {
            //     string[] lines = text.Split('\n');
            //     float lineHeight = font.Size + 2;

            //     Phrase phrase = new Phrase();
            //     foreach (string line in lines)
            //     {
            //         phrase.Add(new Chunk(line, font));
            //         phrase.Add(new Chunk(Chunk.NEWLINE));
            //     }

            //     return phrase;
            // }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}