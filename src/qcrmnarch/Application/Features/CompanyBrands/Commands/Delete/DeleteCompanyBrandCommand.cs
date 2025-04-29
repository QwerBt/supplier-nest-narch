using Application.Features.CompanyBrands.Constants;
using Application.Features.CompanyBrands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.CompanyBrands.Commands.Delete;

public class DeleteCompanyBrandCommand : IRequest<DeletedCompanyBrandResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyBrands"];

    public class DeleteCompanyBrandCommandHandler : IRequestHandler<DeleteCompanyBrandCommand, DeletedCompanyBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyBrandRepository _companyBrandRepository;
        private readonly CompanyBrandBusinessRules _companyBrandBusinessRules;

        public DeleteCompanyBrandCommandHandler(IMapper mapper, ICompanyBrandRepository companyBrandRepository,
                                         CompanyBrandBusinessRules companyBrandBusinessRules)
        {
            _mapper = mapper;
            _companyBrandRepository = companyBrandRepository;
            _companyBrandBusinessRules = companyBrandBusinessRules;
        }

        public async Task<DeletedCompanyBrandResponse> Handle(DeleteCompanyBrandCommand request, CancellationToken cancellationToken)
        {
            CompanyBrand? companyBrand = await _companyBrandRepository.GetAsync(predicate: cb => cb.Id == request.Id, cancellationToken: cancellationToken);
            await _companyBrandBusinessRules.CompanyBrandShouldExistWhenSelected(companyBrand);

            await _companyBrandRepository.DeleteAsync(companyBrand!);

            DeletedCompanyBrandResponse response = _mapper.Map<DeletedCompanyBrandResponse>(companyBrand);
            return response;
        }
    }
}