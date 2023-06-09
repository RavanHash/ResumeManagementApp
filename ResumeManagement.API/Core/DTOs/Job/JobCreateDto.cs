using ResumeManagement.API.Core.Enums;

namespace ResumeManagement.API.Core.DTOs.Job;

public class JobCreateDto
{
    public string Title { get; set; }
    public JobLevel Level { get; set; }
    public long CompanyId { get; set; }
}