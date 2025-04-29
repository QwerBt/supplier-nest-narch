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

namespace Application.Features.CompanyServices.Commands.Create;

public class CreateCompanyServiceCommand : IRequest<CreatedCompanyServiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
    public required int ServicesId { get; set; }
    public required Service Service { get; set; }

    public string[] Roles => [Admin, Write, CompanyServicesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyServices"];

    public class CreateCompanyServiceCommandHandler : IRequestHandler<CreateCompanyServiceCommand, CreatedCompanyServiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyServiceRepository _companyServiceRepository;
        private readonly CompanyServiceBusinessRules _companyServiceBusinessRules;

        public CreateCompanyServiceCommandHandler(IMapper mapper, ICompanyServiceRepository companyServiceRepository,
                                         CompanyServiceBusinessRules companyServiceBusinessRules)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
            _companyServiceBusinessRules = companyServiceBusinessRules;
        }

        public async Task<CreatedCompanyServiceResponse> Handle(CreateCompanyServiceCommand request, CancellationToken cancellationToken)
        {
            CompanyService companyService = _mapper.Map<CompanyService>(request);

            await _companyServiceRepository.AddAsync(companyService);

            CreatedCompanyServiceResponse response = _mapper.Map<CreatedCompanyServiceResponse>(companyService);
            return response;
        }
    }
}