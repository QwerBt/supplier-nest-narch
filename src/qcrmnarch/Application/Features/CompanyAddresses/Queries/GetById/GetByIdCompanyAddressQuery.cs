using Application.Features.CompanyAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CompanyAddresses.Queries.GetById;

public class GetByIdCompanyAddressQuery : IRequest<GetByIdCompanyAddressResponse>
{
    public int Id { get; set; }

    public class GetByIdCompanyAddressQueryHandler : IRequestHandler<GetByIdCompanyAddressQuery, GetByIdCompanyAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyAddressRepository _companyAddressRepository;
        private readonly CompanyAddressBusinessRules _companyAddressBusinessRules;

        public GetByIdCompanyAddressQueryHandler(IMapper mapper, ICompanyAddressRepository companyAddressRepository, CompanyAddressBusinessRules companyAddressBusinessRules)
        {
            _mapper = mapper;
            _companyAddressRepository = companyAddressRepository;
            _companyAddressBusinessRules = companyAddressBusinessRules;
        }

        public async Task<GetByIdCompanyAddressResponse> Handle(GetByIdCompanyAddressQuery request, CancellationToken cancellationToken)
        {
            CompanyAddress? companyAddress = await _companyAddressRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _companyAddressBusinessRules.CompanyAddressShouldExistWhenSelected(companyAddress);

            GetByIdCompanyAddressResponse response = _mapper.Map<GetByIdCompanyAddressResponse>(companyAddress);
            return response;
        }
    }
}