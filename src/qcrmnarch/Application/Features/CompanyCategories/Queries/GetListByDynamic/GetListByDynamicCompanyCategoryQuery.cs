using Application.Features.CompanyCategories.Rules;
using AutoMapper;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Responses;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using Application.Features.CompanyCategories.Constants;

namespace Application.Features.CompanyCategories.Queries.GetListByDynamic;

public class GetListByDynamicQuery : IRequest<GetListResponse<GetListByDynamicCompanyCategoryResponse>>, ILoggableRequest,  ISecuredRequest
{

    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [CompanyCategoriesOperationClaims.Read];

    public class GetListByDynamicQueryHandler : IRequestHandler<GetListByDynamicQuery, GetListResponse<GetListByDynamicCompanyCategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly CompanyCategoryBusinessRules _companyCategoryBusinessRules;
        private readonly ICompanyCategoryRepository _companyCategoryRepository;

        public GetListByDynamicQueryHandler(IMapper mapper, CompanyCategoryBusinessRules companyCategoryBusinessRules, ICompanyCategoryRepository companyCategoryRepository)
        {
            _mapper = mapper;
            _companyCategoryBusinessRules = companyCategoryBusinessRules;
            _companyCategoryRepository = companyCategoryRepository;
    }


    public async Task< GetListResponse<GetListByDynamicCompanyCategoryResponse>> Handle(GetListByDynamicQuery request, CancellationToken cancellationToken)
        {
            var companyCategories = await _companyCategoryRepository.GetListByDynamicAsync(
                request.DynamicQuery,   
                include:c=>c.Include(cat=>cat.Category).Include(x => x.Company),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            var response = _mapper.Map < GetListResponse<GetListByDynamicCompanyCategoryResponse>>(companyCategories);
            return response;
        }

   
    }
 
}
