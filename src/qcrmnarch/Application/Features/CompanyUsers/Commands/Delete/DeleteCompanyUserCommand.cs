using Application.Features.CompanyUsers.Constants;
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

namespace Application.Features.CompanyUsers.Commands.Delete;

public class DeleteCompanyUserCommand : IRequest<DeletedCompanyUserResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CompanyUsersOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyUsers"];

    public class DeleteCompanyUserCommandHandler : IRequestHandler<DeleteCompanyUserCommand, DeletedCompanyUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly CompanyUserBusinessRules _companyUserBusinessRules;

        public DeleteCompanyUserCommandHandler(IMapper mapper, ICompanyUserRepository companyUserRepository,
                                         CompanyUserBusinessRules companyUserBusinessRules)
        {
            _mapper = mapper;
            _companyUserRepository = companyUserRepository;
            _companyUserBusinessRules = companyUserBusinessRules;
        }

        public async Task<DeletedCompanyUserResponse> Handle(DeleteCompanyUserCommand request, CancellationToken cancellationToken)
        {
            CompanyUser? companyUser = await _companyUserRepository.GetAsync(predicate: cu => cu.Id == request.Id, cancellationToken: cancellationToken);
            await _companyUserBusinessRules.CompanyUserShouldExistWhenSelected(companyUser);

            await _companyUserRepository.DeleteAsync(companyUser!);

            DeletedCompanyUserResponse response = _mapper.Map<DeletedCompanyUserResponse>(companyUser);
            return response;
        }
    }
}