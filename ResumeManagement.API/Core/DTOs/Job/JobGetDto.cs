using ResumeManagement.API.Core.Enums;

namespace ResumeManagement.API.Core.DTOs.Job;

public class JobGetDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public JobLevel Level { get; set; }
    public long CompanyId { get; set; }
    public string CompanyName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}