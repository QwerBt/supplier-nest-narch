using Application.Features.CompanyContacts.Constants;
using Application.Features.CompanyContacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CompanyContacts.Constants.CompanyContactsOperationClaims;

namespace Application.Features.CompanyContacts.Queries.GetById;

public class GetByIdCompanyContactQuery : IRequest<GetByIdCompanyContactResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCompanyContactQueryHandler : IRequestHandler<GetByIdCompanyContactQuery, GetByIdCompanyContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyContactRepository _companyContactRepository;
        private readonly CompanyContactBusinessRules _companyContactBusinessRules;

        public GetByIdCompanyContactQueryHandler(IMapper mapper, ICompanyContactRepository companyContactRepository, CompanyContactBusinessRules companyContactBusinessRules)
        {
            _mapper = mapper;
            _companyContactRepository = companyContactRepository;
            _companyContactBusinessRules = companyContactBusinessRules;
        }

        public async Task<GetByIdCompanyContactResponse> Handle(GetByIdCompanyContactQuery request, CancellationToken cancellationToken)
        {
            CompanyContact? companyContact = await _companyContactRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _companyContactBusinessRules.CompanyContactShouldExistWhenSelected(companyContact);

            GetByIdCompanyContactResponse response = _mapper.Map<GetByIdCompanyContactResponse>(companyContact);
            return response;
        }
    }
}