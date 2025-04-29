using Application.Features.CompanyCategories.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CompanyCategories.Constants.CompanyCategoriesOperationClaims;
using NArchitecture.Core.Persistence.Dynamic;
using Microsoft.EntityFrameworkCore;
using Application.Features.Categories.Queries.GetList;
using System.Linq;

namespace Application.Features.CompanyCategories.Queries.GetList;

public class GetListCompanyCategoryQuery : IRequest<GetListResponse<GetListCompanyCategoryListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCompanyCategories({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCompanyCategories";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyCategoryQueryHandler : IRequestHandler<GetListCompanyCategoryQuery, GetListResponse<GetListCompanyCategoryListItemDto>>
    {
        private readonly ICompanyCategoryRepository _companyCategoryRepository;
        private readonly IMapper _mapper;

        public GetListCompanyCategoryQueryHandler(ICompanyCategoryRepository companyCategoryRepository, IMapper mapper)
        {
            _companyCategoryRepository = companyCategoryRepository;
            _mapper = mapper;
        }

        //public async Task<GetListResponse<GetListCompanyCategoryListItemDto>> Handle(GetListCompanyCategoryQuery request, CancellationToken cancellationToken)
        //{
        //    IPaginate<CompanyCategory> companyCategories = await _companyCategoryRepository.GetListAsync(
        //        include:c=>c.Include(x=>x.Category).Include(x => x.Company).Include(x => x.Category.Products).ThenInclude(x=>x.Items),
        //        index: request.PageRequest.PageIndex,
        //        size: request.PageRequest.PageSize, 
        //        cancellationToken: cancellationToken
        //    );

        //    GetListResponse<GetListCompanyCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyCategoryListItemDto>>(companyCategories);
        //    return response;
        //}

        public async Task<GetListResponse<GetListCompanyCategoryListItemDto>> Handle(GetListCompanyCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CompanyCategory> companyCategories = await _companyCategoryRepository.GetListAsync(
                include: c => c.Include(x => x.Category)
                               .Include(x => x.Company)
                               .Include(x => x.Category.Products)
                               .ThenInclude(x => x.Items),
                index: 0,
                size: 999999999,
                cancellationToken: cancellationToken
            );

            var groupedCompanyCategories = companyCategories.Items
                .GroupBy(cc => cc.CompanyId)
                .Select(group => new GetListCompanyCategoryListItemDto
                {
                    CompanyId = group.Key,
                    CompanyName = group.First().Company.Name,
                    ProductsCount = group.SelectMany(c => c.Category.Products).Distinct().Count(), // Toplam benzersiz ürün sayýsý
                    ItemsCount = group.SelectMany(c => c.Category.Products) // Tüm ürünleri düzleþtir
                                      .SelectMany(p => p.Items) // Tüm ürünlerin içindeki item'larý düzleþtir
                                      .Count() // Toplam item sayýsýný al
                })
                .Skip(companyCategories.Index)
                .Take(companyCategories.Size).ToList();

            GetListResponse<GetListCompanyCategoryListItemDto> response = new GetListResponse<GetListCompanyCategoryListItemDto>
            {
                Items = groupedCompanyCategories,
                Count = groupedCompanyCategories.Count,
                Index = request.PageRequest.PageIndex,
                Size = request.PageRequest.PageSize
            };

            return response;
        }


    }
}