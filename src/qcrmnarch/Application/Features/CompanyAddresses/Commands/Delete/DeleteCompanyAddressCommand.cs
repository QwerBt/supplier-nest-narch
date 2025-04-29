using Application.Features.CompanyAddresses.Constants;
using Application.Features.CompanyAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.CompanyAddresses.Commands.Delete;

public class DeleteCompanyAddressCommand : IRequest<DeletedCompanyAddressResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyAddresses"];

    public class DeleteCompanyAddressCommandHandler : IRequestHandler<DeleteCompanyAddressCommand, DeletedCompanyAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyAddressRepository _companyAddressRepository;
        private readonly CompanyAddressBusinessRules _companyAddressBusinessRules;

        public DeleteCompanyAddressCommandHandler(IMapper mapper, ICompanyAddressRepository companyAddressRepository,
                                         CompanyAddressBusinessRules companyAddressBusinessRules)
        {
            _mapper = mapper;
            _companyAddressRepository = companyAddressRepository;
            _companyAddressBusinessRules = companyAddressBusinessRules;
        }

        public async Task<DeletedCompanyAddressResponse> Handle(DeleteCompanyAddressCommand request, CancellationToken cancellationToken)
        {
            CompanyAddress? companyAddress = await _companyAddressRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _companyAddressBusinessRules.CompanyAddressShouldExistWhenSelected(companyAddress);

            await _companyAddressRepository.DeleteAsync(companyAddress!);

            DeletedCompanyAddressResponse response = _mapper.Map<DeletedCompanyAddressResponse>(companyAddress);
            return response;
        }
    }
}