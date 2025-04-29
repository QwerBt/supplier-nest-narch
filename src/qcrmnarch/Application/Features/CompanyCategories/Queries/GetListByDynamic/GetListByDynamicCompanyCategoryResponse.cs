using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyCategories.Queries.GetListByDynamic;

public class GetListByDynamicCompanyCategoryResponse : IResponse {

    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int CategoryId{ get; set; }
    public string CategoryName { get; set; }
    public string CompanyName { get; set; }

}
