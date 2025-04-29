using Application.Features.CompanyServices.Constants;
using Application.Features.CompanyServices.Constants;
using Application.Features.CompanyServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CompanyServices.Constants.CompanyServicesOperationClaims;

namespace Application.Features.CompanyServices.Commands.Delete;

public class DeleteCompanyServiceCommand : IRequest<DeletedCompanyServiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CompanyServicesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyServices"];

    public class DeleteCompanyServiceCommandHandler : IRequestHandler<DeleteCompanyServiceCommand, DeletedCompanyServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyServiceRepository _companyServiceRepository;
        private readonly CompanyServiceBusinessRules _companyServiceBusinessRules;

        public DeleteCompanyServiceCommandHandler(IMapper mapper, ICompanyServiceRepository companyServiceRepository,
                                         CompanyServiceBusinessRules companyServiceBusinessRules)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
            _companyServiceBusinessRules = companyServiceBusinessRules;
        }

        public async Task<DeletedCompanyServiceResponse> Handle(DeleteCompanyServiceCommand request, CancellationToken cancellationToken)
        {
            CompanyService? companyService = await _companyServiceRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _companyServiceBusinessRules.CompanyServiceShouldExistWhenSelected(companyService);

            await _companyServiceRepository.DeleteAsync(companyService!);

            DeletedCompanyServiceResponse response = _mapper.Map<DeletedCompanyServiceResponse>(companyService);
            return response;
        }
    }
}