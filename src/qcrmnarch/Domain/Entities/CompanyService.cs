using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CompanyService:Entity<int>
{
    public CompanyService()
    {
    }

    public CompanyService(int companyId, Company company, int servicesId, Service service) : this()
    {
        CompanyId = companyId;
        Company = company;
        ServicesId = servicesId;
        Service = service;
    }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int ServicesId { get; set; }
    public Service Service { get; set; }


}
