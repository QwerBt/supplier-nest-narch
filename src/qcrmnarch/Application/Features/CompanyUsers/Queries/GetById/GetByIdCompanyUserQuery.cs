using Application.Features.CompanyUsers.Constants;
using Application.Features.CompanyUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CompanyUsers.Constants.CompanyUsersOperationClaims;

namespace Application.Features.CompanyUsers.Queries.GetById;

public class GetByIdCompanyUserQuery : IRequest<GetByIdCompanyUserResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCompanyUserQueryHandler : IRequestHandler<GetByIdCompanyUserQuery, GetByIdCompanyUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly CompanyUserBusinessRules _companyUserBusinessRules;

        public GetByIdCompanyUserQueryHandler(IMapper mapper, ICompanyUserRepository companyUserRepository, CompanyUserBusinessRules companyUserBusinessRules)
        {
            _mapper = mapper;
            _companyUserRepository = companyUserRepository;
            _companyUserBusinessRules = companyUserBusinessRules;
        }

        public async Task<GetByIdCompanyUserResponse> Handle(GetByIdCompanyUserQuery request, CancellationToken cancellationToken)
        {
            CompanyUser? companyUser = await _companyUserRepository.GetAsync(predicate: cu => cu.Id == request.Id, cancellationToken: cancellationToken);
            await _companyUserBusinessRules.CompanyUserShouldExistWhenSelected(companyUser);

            GetByIdCompanyUserResponse response = _mapper.Map<GetByIdCompanyUserResponse>(companyUser);
            return response;
        }
    }
}