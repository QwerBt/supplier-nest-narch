using Application.Features.CompanyImages.Constants;
using Application.Features.CompanyImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CompanyImages.Constants.CompanyImagesOperationClaims;

namespace Application.Features.CompanyImages.Commands.Create;

public class CreateCompanyImageCommand : IRequest<CreatedCompanyImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
    public required string FilePath { get; set; }
    public required string FileName { get; set; }

    public string[] Roles => [Admin, Write, CompanyImagesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyImages"];

    public class CreateCompanyImageCommandHandler : IRequestHandler<CreateCompanyImageCommand, CreatedCompanyImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyImageRepository _companyImageRepository;
        private readonly CompanyImageBusinessRules _companyImageBusinessRules;

        public CreateCompanyImageCommandHandler(IMapper mapper, ICompanyImageRepository companyImageRepository,
                                         CompanyImageBusinessRules companyImageBusinessRules)
        {
            _mapper = mapper;
            _companyImageRepository = companyImageRepository;
            _companyImageBusinessRules = companyImageBusinessRules;
        }

        public async Task<CreatedCompanyImageResponse> Handle(CreateCompanyImageCommand request, CancellationToken cancellationToken)
        {
            CompanyImage companyImage = _mapper.Map<CompanyImage>(request);

            await _companyImageRepository.AddAsync(companyImage);

            CreatedCompanyImageResponse response = _mapper.Map<CreatedCompanyImageResponse>(companyImage);
            return response;
        }
    }
}