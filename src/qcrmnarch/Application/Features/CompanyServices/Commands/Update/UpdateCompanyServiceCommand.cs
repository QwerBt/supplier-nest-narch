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

namespace Application.Features.CompanyServices.Commands.Update;

public class UpdateCompanyServiceCommand : IRequest<UpdatedCompanyServiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
    public required int ServicesId { get; set; }
    public required Service Service { get; set; }

    public string[] Roles => [Admin, Write, CompanyServicesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyServices"];

    public class UpdateCompanyServiceCommandHandler : IRequestHandler<UpdateCompanyServiceCommand, UpdatedCompanyServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyServiceRepository _companyServiceRepository;
        private readonly CompanyServiceBusinessRules _companyServiceBusinessRules;

        public UpdateCompanyServiceCommandHandler(IMapper mapper, ICompanyServiceRepository companyServiceRepository,
                                         CompanyServiceBusinessRules companyServiceBusinessRules)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
            _companyServiceBusinessRules = companyServiceBusinessRules;
        }

        public async Task<UpdatedCompanyServiceResponse> Handle(UpdateCompanyServiceCommand request, CancellationToken cancellationToken)
        {
            CompanyService? companyService = await _companyServiceRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _companyServiceBusinessRules.CompanyServiceShouldExistWhenSelected(companyService);
            companyService = _mapper.Map(request, companyService);

            await _companyServiceRepository.UpdateAsync(companyService!);

            UpdatedCompanyServiceResponse response = _mapper.Map<UpdatedCompanyServiceResponse>(companyService);
            return response;
        }
    }
}