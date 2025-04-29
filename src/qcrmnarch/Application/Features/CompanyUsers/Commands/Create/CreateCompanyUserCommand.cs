using Application.Features.CompanyUsers.Constants;
using Application.Features.CompanyUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CompanyUsers.Constants.CompanyUsersOperationClaims;

namespace Application.Features.CompanyUsers.Commands.Create;

public class CreateCompanyUserCommand : IRequest<CreatedCompanyUserResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
    public required Guid UserId { get; set; }
    public required User User { get; set; }

    public string[] Roles => [Admin, Write, CompanyUsersOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyUsers"];

    public class CreateCompanyUserCommandHandler : IRequestHandler<CreateCompanyUserCommand, CreatedCompanyUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly CompanyUserBusinessRules _companyUserBusinessRules;

        public CreateCompanyUserCommandHandler(IMapper mapper, ICompanyUserRepository companyUserRepository,
                                         CompanyUserBusinessRules companyUserBusinessRules)
        {
            _mapper = mapper;
            _companyUserRepository = companyUserRepository;
            _companyUserBusinessRules = companyUserBusinessRules;
        }

        public async Task<CreatedCompanyUserResponse> Handle(CreateCompanyUserCommand request, CancellationToken cancellationToken)
        {
            CompanyUser companyUser = _mapper.Map<CompanyUser>(request);

            await _companyUserRepository.AddAsync(companyUser);

            CreatedCompanyUserResponse response = _mapper.Map<CreatedCompanyUserResponse>(companyUser);
            return response;
        }
    }
}