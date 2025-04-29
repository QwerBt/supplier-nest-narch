using Application.Features.CompanyServices.Constants;
using Application.Features.CompanyServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CompanyServices.Constants.CompanyServicesOperationClaims;

namespace Application.Features.CompanyServices.Queries.GetById;

public class GetByIdCompanyServiceQuery : IRequest<GetByIdCompanyServiceResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCompanyServiceQueryHandler : IRequestHandler<GetByIdCompanyServiceQuery, GetByIdCompanyServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyServiceRepository _companyServiceRepository;
        private readonly CompanyServiceBusinessRules _companyServiceBusinessRules;

        public GetByIdCompanyServiceQueryHandler(IMapper mapper, ICompanyServiceRepository companyServiceRepository, CompanyServiceBusinessRules companyServiceBusinessRules)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
            _companyServiceBusinessRules = companyServiceBusinessRules;
        }

        public async Task<GetByIdCompanyServiceResponse> Handle(GetByIdCompanyServiceQuery request, CancellationToken cancellationToken)
        {
            CompanyService? companyService = await _companyServiceRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _companyServiceBusinessRules.CompanyServiceShouldExistWhenSelected(companyService);

            GetByIdCompanyServiceResponse response = _mapper.Map<GetByIdCompanyServiceResponse>(companyService);
            return response;
        }
    }
}