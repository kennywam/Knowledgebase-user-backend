<<<<<<< HEAD
﻿// PdfController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PdfController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly PdfGenerationService _pdfService;

    public PdfController(AppDbContext dbContext, PdfGenerationService pdfService)
    {
        _dbContext = dbContext;
        _pdfService = pdfService;
    }

    [HttpPost("generate")]
    public IActionResult GeneratePDF([FromBody] int cdrDataId)
    {
        var cdrData = _dbContext.CDRData.FirstOrDefault(c => c.Id == cdrDataId);
        if (cdrData == null)
        {
            return NotFound("CDR data not found.");
        }

        var pdfBytes = _pdfService.GeneratePDFWithTemplate(cdrData);
        return File(pdfBytes, "application/pdf", "generated.pdf");
    }

=======
﻿namespace CDR_project.controllers
{
    public class PdfController
    {
    }
}
>>>>>>> ebadd27 (Initial commit)
