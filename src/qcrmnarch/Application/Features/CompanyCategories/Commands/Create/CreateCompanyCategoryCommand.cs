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

namespace Application.Features.CompanyCategories.Commands.Create;

public class CreateCompanyCategoryCommand : IRequest<CreatedCompanyCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int CompanyId { get; set; }
    public required int CategoryId { get; set; }

    public string[] Roles => [Admin, Write, CompanyCategoriesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyCategories"];

    public class CreateCompanyCategoryCommandHandler : IRequestHandler<CreateCompanyCategoryCommand, CreatedCompanyCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyCategoryRepository _companyCategoryRepository;
        private readonly CompanyCategoryBusinessRules _companyCategoryBusinessRules;

        public CreateCompanyCategoryCommandHandler(IMapper mapper, ICompanyCategoryRepository companyCategoryRepository,
                                         CompanyCategoryBusinessRules companyCategoryBusinessRules)
        {
            _mapper = mapper;
            _companyCategoryRepository = companyCategoryRepository;
            _companyCategoryBusinessRules = companyCategoryBusinessRules;
        }

        public async Task<CreatedCompanyCategoryResponse> Handle(CreateCompanyCategoryCommand request, CancellationToken cancellationToken)
        {
            CompanyCategory companyCategory = _mapper.Map<CompanyCategory>(request);

            await _companyCategoryRepository.AddAsync(companyCategory);

            CreatedCompanyCategoryResponse response = _mapper.Map<CreatedCompanyCategoryResponse>(companyCategory);
            return response;
        }
    }
}