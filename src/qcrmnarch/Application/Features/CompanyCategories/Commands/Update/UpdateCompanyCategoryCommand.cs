using Application.Features.CompanyCategories.Constants;
using Application.Features.CompanyCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CompanyCategories.Constants.CompanyCategoriesOperationClaims;

namespace Application.Features.CompanyCategories.Commands.Update;

public class UpdateCompanyCategoryCommand : IRequest<UpdatedCompanyCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int CompanyId { get; set; }
    public required int CategoryId { get; set; }

    public string[] Roles => [Admin, Write, CompanyCategoriesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyCategories"];

    public class UpdateCompanyCategoryCommandHandler : IRequestHandler<UpdateCompanyCategoryCommand, UpdatedCompanyCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyCategoryRepository _companyCategoryRepository;
        private readonly CompanyCategoryBusinessRules _companyCategoryBusinessRules;

        public UpdateCompanyCategoryCommandHandler(IMapper mapper, ICompanyCategoryRepository companyCategoryRepository,
                                         CompanyCategoryBusinessRules companyCategoryBusinessRules)
        {
            _mapper = mapper;
            _companyCategoryRepository = companyCategoryRepository;
            _companyCategoryBusinessRules = companyCategoryBusinessRules;
        }

        public async Task<UpdatedCompanyCategoryResponse> Handle(UpdateCompanyCategoryCommand request, CancellationToken cancellationToken)
        {
            CompanyCategory? companyCategory = await _companyCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _companyCategoryBusinessRules.CompanyCategoryShouldExistWhenSelected(companyCategory);
            companyCategory = _mapper.Map(request, companyCategory);

            await _companyCategoryRepository.UpdateAsync(companyCategory!);

            UpdatedCompanyCategoryResponse response = _mapper.Map<UpdatedCompanyCategoryResponse>(companyCategory);
            return response;
        }
    }
}