using AutoMapper;
using ResumeManagement.API.Core.DTOs.Company;
using ResumeManagement.API.Core.Entities;

namespace ResumeManagement.API.Core.AutoMapperConfig;

public class AutoMapperConfigProfile : Profile
{
    public AutoMapperConfigProfile()
    {
        CreateMap<CompanyCreateDto, Company>();
        CreateMap<Company, CompanyGetDto>();
    }
}