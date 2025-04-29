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

namespace Application.Features.CompanyUsers.Commands.Update;

public class UpdateCompanyUserCommand : IRequest<UpdatedCompanyUserResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
    public required Guid UserId { get; set; }
    public required User User { get; set; }

    public string[] Roles => [Admin, Write, CompanyUsersOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyUsers"];

    public class UpdateCompanyUserCommandHandler : IRequestHandler<UpdateCompanyUserCommand, UpdatedCompanyUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly CompanyUserBusinessRules _companyUserBusinessRules;

        public UpdateCompanyUserCommandHandler(IMapper mapper, ICompanyUserRepository companyUserRepository,
                                         CompanyUserBusinessRules companyUserBusinessRules)
        {
            _mapper = mapper;
            _companyUserRepository = companyUserRepository;
            _companyUserBusinessRules = companyUserBusinessRules;
        }

        public async Task<UpdatedCompanyUserResponse> Handle(UpdateCompanyUserCommand request, CancellationToken cancellationToken)
        {
            CompanyUser? companyUser = await _companyUserRepository.GetAsync(predicate: cu => cu.Id == request.Id, cancellationToken: cancellationToken);
            await _companyUserBusinessRules.CompanyUserShouldExistWhenSelected(companyUser);
            companyUser = _mapper.Map(request, companyUser);

            await _companyUserRepository.UpdateAsync(companyUser!);

            UpdatedCompanyUserResponse response = _mapper.Map<UpdatedCompanyUserResponse>(companyUser);
            return response;
        }
    }
}