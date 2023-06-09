using ResumeManagement.API.Core.Enums;

namespace ResumeManagement.API.Core.DTOs.Company;

public class CompanyGetDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public CompanySize Size { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}