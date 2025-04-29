using Application.Features.CompanyBrands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.CompanyBrands.Commands.Update;

public class UpdateCompanyBrandCommand : IRequest<UpdatedCompanyBrandResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyBrands"];

    public class UpdateCompanyBrandCommandHandler : IRequestHandler<UpdateCompanyBrandCommand, UpdatedCompanyBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyBrandRepository _companyBrandRepository;
        private readonly CompanyBrandBusinessRules _companyBrandBusinessRules;

        public UpdateCompanyBrandCommandHandler(IMapper mapper, ICompanyBrandRepository companyBrandRepository,
                                         CompanyBrandBusinessRules companyBrandBusinessRules)
        {
            _mapper = mapper;
            _companyBrandRepository = companyBrandRepository;
            _companyBrandBusinessRules = companyBrandBusinessRules;
        }

        public async Task<UpdatedCompanyBrandResponse> Handle(UpdateCompanyBrandCommand request, CancellationToken cancellationToken)
        {
            CompanyBrand? companyBrand = await _companyBrandRepository.GetAsync(predicate: cb => cb.Id == request.Id, cancellationToken: cancellationToken);
            await _companyBrandBusinessRules.CompanyBrandShouldExistWhenSelected(companyBrand);
            companyBrand = _mapper.Map(request, companyBrand);

            await _companyBrandRepository.UpdateAsync(companyBrand!);

            UpdatedCompanyBrandResponse response = _mapper.Map<UpdatedCompanyBrandResponse>(companyBrand);
            return response;
        }
    }
}