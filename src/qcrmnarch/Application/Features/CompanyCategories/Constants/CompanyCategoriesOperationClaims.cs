namespace Application.Features.CompanyCategories.Constants;

public static class CompanyCategoriesOperationClaims
{
    private const string _section = "CompanyCategories";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
    
    public const string GetByCompanyId = $"{_section}.GetByCompanyId";
    
    public const string GetListByDynamic = $"{_section}.GetListByDynamic";
}
