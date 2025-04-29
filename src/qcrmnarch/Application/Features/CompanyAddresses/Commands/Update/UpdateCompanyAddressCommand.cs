using Application.Features.CompanyAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.CompanyAddresses.Commands.Update;

public class UpdateCompanyAddressCommand : IRequest<UpdatedCompanyAddressResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public required string Street { get; set; }
    public required int CityId { get; set; }
    public required City City { get; set; }
    public required int TownId { get; set; }
    public required Town Town { get; set; }
    public required int CountryId { get; set; }
    public required Country Country { get; set; }
    public required string PostalCode { get; set; }
    public required string Description { get; set; }
    public required int CompanyId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyAddresses"];

    public class UpdateCompanyAddressCommandHandler : IRequestHandler<UpdateCompanyAddressCommand, UpdatedCompanyAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyAddressRepository _companyAddressRepository;
        private readonly CompanyAddressBusinessRules _companyAddressBusinessRules;

        public UpdateCompanyAddressCommandHandler(IMapper mapper, ICompanyAddressRepository companyAddressRepository,
                                         CompanyAddressBusinessRules companyAddressBusinessRules)
        {
            _mapper = mapper;
            _companyAddressRepository = companyAddressRepository;
            _companyAddressBusinessRules = companyAddressBusinessRules;
        }

        public async Task<UpdatedCompanyAddressResponse> Handle(UpdateCompanyAddressCommand request, CancellationToken cancellationToken)
        {
            CompanyAddress? companyAddress = await _companyAddressRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _companyAddressBusinessRules.CompanyAddressShouldExistWhenSelected(companyAddress);
            companyAddress = _mapper.Map(request, companyAddress);

            await _companyAddressRepository.UpdateAsync(companyAddress!);

            UpdatedCompanyAddressResponse response = _mapper.Map<UpdatedCompanyAddressResponse>(companyAddress);
            return response;
        }
    }
}