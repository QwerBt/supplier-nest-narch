using Application.Features.CompanyImages.Constants;
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

namespace Application.Features.CompanyImages.Commands.Delete;

public class DeleteCompanyImageCommand : IRequest<DeletedCompanyImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CompanyImagesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyImages"];

    public class DeleteCompanyImageCommandHandler : IRequestHandler<DeleteCompanyImageCommand, DeletedCompanyImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyImageRepository _companyImageRepository;
        private readonly CompanyImageBusinessRules _companyImageBusinessRules;

        public DeleteCompanyImageCommandHandler(IMapper mapper, ICompanyImageRepository companyImageRepository,
                                         CompanyImageBusinessRules companyImageBusinessRules)
        {
            _mapper = mapper;
            _companyImageRepository = companyImageRepository;
            _companyImageBusinessRules = companyImageBusinessRules;
        }

        public async Task<DeletedCompanyImageResponse> Handle(DeleteCompanyImageCommand request, CancellationToken cancellationToken)
        {
            CompanyImage? companyImage = await _companyImageRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _companyImageBusinessRules.CompanyImageShouldExistWhenSelected(companyImage);

            await _companyImageRepository.DeleteAsync(companyImage!);

            DeletedCompanyImageResponse response = _mapper.Map<DeletedCompanyImageResponse>(companyImage);
            return response;
        }
    }
}