using Application.Features.CompanyImages.Constants;
using Application.Features.CompanyImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CompanyImages.Constants.CompanyImagesOperationClaims;

namespace Application.Features.CompanyImages.Queries.GetById;

public class GetByIdCompanyImageQuery : IRequest<GetByIdCompanyImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCompanyImageQueryHandler : IRequestHandler<GetByIdCompanyImageQuery, GetByIdCompanyImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyImageRepository _companyImageRepository;
        private readonly CompanyImageBusinessRules _companyImageBusinessRules;

        public GetByIdCompanyImageQueryHandler(IMapper mapper, ICompanyImageRepository companyImageRepository, CompanyImageBusinessRules companyImageBusinessRules)
        {
            _mapper = mapper;
            _companyImageRepository = companyImageRepository;
            _companyImageBusinessRules = companyImageBusinessRules;
        }

        public async Task<GetByIdCompanyImageResponse> Handle(GetByIdCompanyImageQuery request, CancellationToken cancellationToken)
        {
            CompanyImage? companyImage = await _companyImageRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _companyImageBusinessRules.CompanyImageShouldExistWhenSelected(companyImage);

            GetByIdCompanyImageResponse response = _mapper.Map<GetByIdCompanyImageResponse>(companyImage);
            return response;
        }
    }
}