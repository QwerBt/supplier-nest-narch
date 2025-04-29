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

namespace Application.Features.CompanyImages.Commands.Update;

public class UpdateCompanyImageCommand : IRequest<UpdatedCompanyImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required int CompanyId { get; set; }
    public required Company Company { get; set; }
    public required string FilePath { get; set; }
    public required string FileName { get; set; }

    public string[] Roles => [Admin, Write, CompanyImagesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyImages"];

    public class UpdateCompanyImageCommandHandler : IRequestHandler<UpdateCompanyImageCommand, UpdatedCompanyImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyImageRepository _companyImageRepository;
        private readonly CompanyImageBusinessRules _companyImageBusinessRules;

        public UpdateCompanyImageCommandHandler(IMapper mapper, ICompanyImageRepository companyImageRepository,
                                         CompanyImageBusinessRules companyImageBusinessRules)
        {
            _mapper = mapper;
            _companyImageRepository = companyImageRepository;
            _companyImageBusinessRules = companyImageBusinessRules;
        }

        public async Task<UpdatedCompanyImageResponse> Handle(UpdateCompanyImageCommand request, CancellationToken cancellationToken)
        {
            CompanyImage? companyImage = await _companyImageRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _companyImageBusinessRules.CompanyImageShouldExistWhenSelected(companyImage);
            companyImage = _mapper.Map(request, companyImage);

            await _companyImageRepository.UpdateAsync(companyImage!);

            UpdatedCompanyImageResponse response = _mapper.Map<UpdatedCompanyImageResponse>(companyImage);
            return response;
        }
    }
}