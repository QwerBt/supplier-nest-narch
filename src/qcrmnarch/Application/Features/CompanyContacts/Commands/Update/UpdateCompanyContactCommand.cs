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

namespace Application.Features.CompanyContacts.Commands.Update;

public class UpdateCompanyContactCommand : IRequest<UpdatedCompanyContactResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Phone1 { get; set; }
    public required string Phone2 { get; set; }
    public required string Email { get; set; }
    public required string Position { get; set; }
    public required bool IsPrimary { get; set; }
    public required int CompanyId { get; set; }

    public string[] Roles => [Admin, Write, CompanyContactsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyContacts"];

    public class UpdateCompanyContactCommandHandler : IRequestHandler<UpdateCompanyContactCommand, UpdatedCompanyContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyContactRepository _companyContactRepository;
        private readonly CompanyContactBusinessRules _companyContactBusinessRules;

        public UpdateCompanyContactCommandHandler(IMapper mapper, ICompanyContactRepository companyContactRepository,
                                         CompanyContactBusinessRules companyContactBusinessRules)
        {
            _mapper = mapper;
            _companyContactRepository = companyContactRepository;
            _companyContactBusinessRules = companyContactBusinessRules;
        }

        public async Task<UpdatedCompanyContactResponse> Handle(UpdateCompanyContactCommand request, CancellationToken cancellationToken)
        {
            CompanyContact? companyContact = await _companyContactRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _companyContactBusinessRules.CompanyContactShouldExistWhenSelected(companyContact);
            companyContact = _mapper.Map(request, companyContact);

            await _companyContactRepository.UpdateAsync(companyContact!);

            UpdatedCompanyContactResponse response = _mapper.Map<UpdatedCompanyContactResponse>(companyContact);
            return response;
        }
    }
}