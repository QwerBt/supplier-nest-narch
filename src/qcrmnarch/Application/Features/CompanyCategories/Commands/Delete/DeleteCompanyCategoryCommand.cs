using Application.Features.CompanyCategories.Constants;
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

namespace Application.Features.CompanyCategories.Commands.Delete;

public class DeleteCompanyCategoryCommand : IRequest<DeletedCompanyCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CompanyCategoriesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyCategories"];

    public class DeleteCompanyCategoryCommandHandler : IRequestHandler<DeleteCompanyCategoryCommand, DeletedCompanyCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyCategoryRepository _companyCategoryRepository;
        private readonly CompanyCategoryBusinessRules _companyCategoryBusinessRules;

        public DeleteCompanyCategoryCommandHandler(IMapper mapper, ICompanyCategoryRepository companyCategoryRepository,
                                         CompanyCategoryBusinessRules companyCategoryBusinessRules)
        {
            _mapper = mapper;
            _companyCategoryRepository = companyCategoryRepository;
            _companyCategoryBusinessRules = companyCategoryBusinessRules;
        }

        public async Task<DeletedCompanyCategoryResponse> Handle(DeleteCompanyCategoryCommand request, CancellationToken cancellationToken)
        {
            CompanyCategory? companyCategory = await _companyCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _companyCategoryBusinessRules.CompanyCategoryShouldExistWhenSelected(companyCategory);

            await _companyCategoryRepository.DeleteAsync(companyCategory!);

            DeletedCompanyCategoryResponse response = _mapper.Map<DeletedCompanyCategoryResponse>(companyCategory);
            return response;
        }
    }
}