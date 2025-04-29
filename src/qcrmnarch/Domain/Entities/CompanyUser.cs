using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CompanyUser:Entity<int>
{
    public CompanyUser()
    {
    }

    public CompanyUser(int companyId, Company company, Guid userId, User user):this()
    {
        CompanyId = companyId;
        Company = company;
        UserId = userId;
        User = user;
    }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}
