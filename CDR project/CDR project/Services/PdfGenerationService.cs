using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf;
using System.Text;

public class PdfGenerationService
{
    public byte[] GeneratePDFWithTemplate(CDRData cdrData)
    {
        using (var templateStream = new FileStream("path_to_template.pdf", FileMode.Open))
        using (var document = PdfReader.Open(templateStream))
        using (var memoryStream = new MemoryStream())
        {
            var page = document.Pages[0];

            // Replace placeholders in header and footer
            ReplacePlaceholder(page, "HEADER_PLACEHOLDER", "Dynamic Header Content");
            ReplacePlaceholder(page, "FOOTER_PLACEHOLDER", "Dynamic Footer Content");

            // Add dynamic content from database
            var gfx = XGraphics.FromPdfPage(page);
            var contentFont = new XFont("Arial", 12);
            var contentText = $"CDR Data: {cdrData.CallDuration}";
            gfx.DrawString(contentText, contentFont, XBrushes.Black, new XRect(10, 100, 400, 20));

            document.Save(memoryStream);
            return memoryStream.ToArray();
        }
    }

    private void ReplacePlaceholder(PdfPage page, string placeholder, string replacement)
    {
        var content = page.Contents;
        var placeholderBytes = Encoding.ASCII.GetBytes(placeholder);
        var replacementBytes = Encoding.ASCII.GetBytes(replacement);
        var index = content.IndexOf(placeholderBytes);
        if (index != -1)
        {
            content.Replace(index, placeholderBytes.Length, replacementBytes);
        }
    }
}
