using CDR_pdf.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace CDR_pdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View( new UserInputModel());
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

                //user details

                Paragraph userParagraph = new Paragraph(
                           $"Email: {userInput.Email}\n" +
                           $"Phone: {userInput.PhoneNumber}\n" +
                           $"Statement Period From: {userInput.StatementPeriodFrom.ToShortDateString()}\n" +
                           $"Statement Period To: {userInput.StatementPeriodTo.ToShortDateString()}");
                userParagraph.SpacingAfter = 20;
                float indentationLeftValue = 60f; 
                userParagraph.IndentationLeft = indentationLeftValue;
                document.Add(userParagraph);
                PdfPTable table = new PdfPTable(4);

                PdfPCell cell1 = new PdfPCell(new Phrase("Date", new Font(Font.FontFamily.HELVETICA,10)));
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                cell1.BorderWidth = 1f;
                cell1.BorderWidthTop = 1f;
                cell1.BorderWidthLeft= 1f;
                cell1.BorderWidthRight= 1f;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell1);


                PdfPCell cell2 = new PdfPCell(new Phrase("Voice", new Font(Font.FontFamily.HELVETICA, 10)));
                cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                cell2.BorderWidth = 1f;
                cell2.BorderWidthTop = 1f;
                cell2.BorderWidthLeft = 1f;
                cell2.BorderWidthRight = 1f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell2);


                PdfPCell cell3 = new PdfPCell(new Phrase("Data", new Font(Font.FontFamily.HELVETICA, 10)));
                cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                cell3.BorderWidth = 1f;
                cell3.BorderWidthTop = 1f;
                cell3.BorderWidthLeft = 1f;
                cell3.BorderWidthRight = 1f;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell(new Phrase("SMS", new Font(Font.FontFamily.HELVETICA, 10)));
                cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER;
                cell3.BorderWidth = 1f;
                cell3.BorderWidthTop = 1f;
                cell3.BorderWidthLeft = 1f;
                cell3.BorderWidthRight = 1f;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell4);

                for (int i = 0; i < 100; i++)
                {
                    PdfPCell cell_1 = new PdfPCell(new Phrase(i.ToString()));
                    PdfPCell cell_2 = new PdfPCell(new Phrase((i+1).ToString()));
                    PdfPCell cell_3 = new PdfPCell(new Phrase((i+3).ToString()));
                    PdfPCell cell_4 = new PdfPCell(new Phrase((i+4).ToString()));


                    table.AddCell(cell_1);
                    table.AddCell(cell_2); 
                    table.AddCell(cell_3);
                    table.AddCell(cell_4);

                }
                document.Add(table);
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
            public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document document)
            {
                base.OnEndPage(writer, document);

                var image = iTextSharp.text.Image.GetInstance("wwwroot/image/img.png");
                image.ScaleToFit(65, 65);

                float x = PageSize.A4.Right - (3 * document.RightMargin) - image.ScaledWidth;
                float y = PageSize.A4.Top - document.TopMargin - image.ScaledHeight;


                image.SetAbsolutePosition(x, y);
                writer.DirectContent.AddImage(image);

                BaseColor textColor = BaseColor.RED; // Change to your desired color
                Font font = new Font(Font.FontFamily.HELVETICA, 12);
                font.Color = textColor;

                ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER,
                    new Phrase("AIRTEL NETWORKS KENYA LIMITED", font),
                    document.PageSize.Width / 2, document.PageSize.Height - document.TopMargin - 35, 0);

                // Add space after the phrase
                float spaceHeight = 20; // Adjust this value for desired space
                writer.DirectContent.MoveText(0, -spaceHeight);

            }
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