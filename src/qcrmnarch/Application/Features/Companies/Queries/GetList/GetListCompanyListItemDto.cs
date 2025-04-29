using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Companies.Queries.GetList;

public class GetListCompanyListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TaxId { get; set; }
    public string Phone1 { get; set; }
    public string Phone2 { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }
    public string BankAccountNumber { get; set; }
    public string BankName { get; set; }
    public bool IsVerified { get; set; }
    public decimal CreditLimit { get; set; }
    public string PaymentTerms { get; set; }
    public string FacebookUrl { get; set; }
    public string TwitterUrl { get; set; }
    public string LinkedInUrl { get; set; }
    public bool IsActive { get; set; }
    public int CompanyIndustryId { get; set; }
}