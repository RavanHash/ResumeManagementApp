﻿using ResumeManagement.API.Core.Enums;

namespace ResumeManagement.API.Core.Entities;

public class Job : BaseEntity
{
    public string Title { get; set; }
    public JobLevel Level { get; set; }
    public long CompanyId { get; set; }
    public Company Company { get; set; }
    public ICollection<Candidate> Candidates { get; set; }
}