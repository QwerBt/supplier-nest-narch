using Application.Features.CompanyBrands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.CompanyBrands.Commands.Create;

public class CreateCompanyBrandCommand : IRequest<CreatedCompanyBrandResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyBrands"];

    public class CreateCompanyBrandCommandHandler : IRequestHandler<CreateCompanyBrandCommand, CreatedCompanyBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyBrandRepository _companyBrandRepository;
        private readonly CompanyBrandBusinessRules _companyBrandBusinessRules;

        public CreateCompanyBrandCommandHandler(IMapper mapper, ICompanyBrandRepository companyBrandRepository,
                                         CompanyBrandBusinessRules companyBrandBusinessRules)
        {
            _mapper = mapper;
            _companyBrandRepository = companyBrandRepository;
            _companyBrandBusinessRules = companyBrandBusinessRules;
        }

        public async Task<CreatedCompanyBrandResponse> Handle(CreateCompanyBrandCommand request, CancellationToken cancellationToken)
        {
            CompanyBrand companyBrand = _mapper.Map<CompanyBrand>(request);

            await _companyBrandRepository.AddAsync(companyBrand);

            CreatedCompanyBrandResponse response = _mapper.Map<CreatedCompanyBrandResponse>(companyBrand);
            return response;
        }
    }
}