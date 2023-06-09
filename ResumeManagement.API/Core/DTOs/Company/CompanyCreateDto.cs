using ResumeManagement.API.Core.Enums;

namespace ResumeManagement.API.Core.DTOs.Company;

public class CompanyCreateDto
{
    public string Name { get; set; }
    public CompanySize Size { get; set; }
}