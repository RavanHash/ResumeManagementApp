using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeManagement.API.Core.Context;
using ResumeManagement.API.Core.DTOs.Candidate;
using ResumeManagement.API.Core.Entities;

namespace ResumeManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateController : ControllerBase
{
    public CandidateController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    private ApplicationDbContext _context { get; }
    private IMapper _mapper { get; }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto dto, IFormFile pdfFile)
    {
        var fiveMegaByte = 5 * 1024 * 1024;
        var pdfMimeType = "application/pdf";

        if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType) return BadRequest("File is not valid");

        var resumeUrl = Guid.NewGuid() + ".pdf";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await pdfFile.CopyToAsync(stream);
        }

        var newCandidate = _mapper.Map<Candidate>(dto);
        newCandidate.ResumeUrl = resumeUrl;
        await _context.Candidates.AddAsync(newCandidate);
        await _context.SaveChangesAsync();

        return Ok("Candidate Saved Successfully");
    }

    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
    {
        var candidates =
            await _context.Candidates.Include(c => c.Job).OrderByDescending(q => q.CreatedAt).ToListAsync();
        var convertedCandidates = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);

        return Ok(convertedCandidates);
    }

    [HttpGet]
    [Route("download/{url}")]
    public IActionResult DownloadPdfFile(string url)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);

        if (!System.IO.File.Exists(filePath)) return NotFound("File Not Found");

        var pdfBytes = System.IO.File.ReadAllBytes(filePath);
        var file = File(pdfBytes, "application/pdf", url);
        return file;
    }
}