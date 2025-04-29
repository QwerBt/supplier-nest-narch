using Application.Features.CompanyContacts.Constants;
using Application.Features.CompanyContacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CompanyContacts.Constants.CompanyContactsOperationClaims;

namespace Application.Features.CompanyContacts.Commands.Create;

public class CreateCompanyContactCommand : IRequest<CreatedCompanyContactResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string FullName { get; set; }
    public required string Phone1 { get; set; }
    public required string Phone2 { get; set; }
    public required string Email { get; set; }
    public required string Position { get; set; }
    public required bool IsPrimary { get; set; }
    public required int CompanyId { get; set; }

    public string[] Roles => [Admin, Write, CompanyContactsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyContacts"];

    public class CreateCompanyContactCommandHandler : IRequestHandler<CreateCompanyContactCommand, CreatedCompanyContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyContactRepository _companyContactRepository;
        private readonly CompanyContactBusinessRules _companyContactBusinessRules;

        public CreateCompanyContactCommandHandler(IMapper mapper, ICompanyContactRepository companyContactRepository,
                                         CompanyContactBusinessRules companyContactBusinessRules)
        {
            _mapper = mapper;
            _companyContactRepository = companyContactRepository;
            _companyContactBusinessRules = companyContactBusinessRules;
        }

        public async Task<CreatedCompanyContactResponse> Handle(CreateCompanyContactCommand request, CancellationToken cancellationToken)
        {
            CompanyContact companyContact = _mapper.Map<CompanyContact>(request);

            await _companyContactRepository.AddAsync(companyContact);

            CreatedCompanyContactResponse response = _mapper.Map<CreatedCompanyContactResponse>(companyContact);
            return response;
        }
    }
}