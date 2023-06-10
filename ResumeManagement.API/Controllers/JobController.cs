using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeManagement.API.Core.Context;
using ResumeManagement.API.Core.DTOs.Job;
using ResumeManagement.API.Core.Entities;

namespace ResumeManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    public JobController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    private ApplicationDbContext _context { get; }
    private IMapper _mapper { get; }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
    {
        var newJob = _mapper.Map<Job>(dto);
        await _context.Jobs.AddAsync(newJob);
        await _context.SaveChangesAsync();

        return Ok("Job Created Successfully");
    }

    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
    {
        var jobs = await _context.Jobs.Include(job => job.Company)
            .OrderByDescending(q => q.CreatedAt).ToListAsync();
        var convertedJobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);

        return Ok(convertedJobs);
    }
}