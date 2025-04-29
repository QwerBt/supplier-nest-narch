using Application.Features.CompanyCategories.Constants;
using Application.Features.CompanyCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CompanyCategories.Constants.CompanyCategoriesOperationClaims;

namespace Application.Features.CompanyCategories.Queries.GetById;

public class GetByIdCompanyCategoryQuery : IRequest<GetByIdCompanyCategoryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCompanyCategoryQueryHandler : IRequestHandler<GetByIdCompanyCategoryQuery, GetByIdCompanyCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyCategoryRepository _companyCategoryRepository;
        private readonly CompanyCategoryBusinessRules _companyCategoryBusinessRules;

        public GetByIdCompanyCategoryQueryHandler(IMapper mapper, ICompanyCategoryRepository companyCategoryRepository, CompanyCategoryBusinessRules companyCategoryBusinessRules)
        {
            _mapper = mapper;
            _companyCategoryRepository = companyCategoryRepository;
            _companyCategoryBusinessRules = companyCategoryBusinessRules;
        }

        public async Task<GetByIdCompanyCategoryResponse> Handle(GetByIdCompanyCategoryQuery request, CancellationToken cancellationToken)
        {
            CompanyCategory? companyCategory = await _companyCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _companyCategoryBusinessRules.CompanyCategoryShouldExistWhenSelected(companyCategory);

            GetByIdCompanyCategoryResponse response = _mapper.Map<GetByIdCompanyCategoryResponse>(companyCategory);
            return response;
        }
    }
}