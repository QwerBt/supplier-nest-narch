using Application.Features.CompanyContacts.Constants;
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

namespace Application.Features.CompanyContacts.Commands.Delete;

public class DeleteCompanyContactCommand : IRequest<DeletedCompanyContactResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CompanyContactsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyContacts"];

    public class DeleteCompanyContactCommandHandler : IRequestHandler<DeleteCompanyContactCommand, DeletedCompanyContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyContactRepository _companyContactRepository;
        private readonly CompanyContactBusinessRules _companyContactBusinessRules;

        public DeleteCompanyContactCommandHandler(IMapper mapper, ICompanyContactRepository companyContactRepository,
                                         CompanyContactBusinessRules companyContactBusinessRules)
        {
            _mapper = mapper;
            _companyContactRepository = companyContactRepository;
            _companyContactBusinessRules = companyContactBusinessRules;
        }

        public async Task<DeletedCompanyContactResponse> Handle(DeleteCompanyContactCommand request, CancellationToken cancellationToken)
        {
            CompanyContact? companyContact = await _companyContactRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _companyContactBusinessRules.CompanyContactShouldExistWhenSelected(companyContact);

            await _companyContactRepository.DeleteAsync(companyContact!);

            DeletedCompanyContactResponse response = _mapper.Map<DeletedCompanyContactResponse>(companyContact);
            return response;
        }
    }
}