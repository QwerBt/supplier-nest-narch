using Application.Features.CompanyBrands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CompanyBrands.Queries.GetById;

public class GetByIdCompanyBrandQuery : IRequest<GetByIdCompanyBrandResponse>
{
    public int Id { get; set; }

    public class GetByIdCompanyBrandQueryHandler : IRequestHandler<GetByIdCompanyBrandQuery, GetByIdCompanyBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyBrandRepository _companyBrandRepository;
        private readonly CompanyBrandBusinessRules _companyBrandBusinessRules;

        public GetByIdCompanyBrandQueryHandler(IMapper mapper, ICompanyBrandRepository companyBrandRepository, CompanyBrandBusinessRules companyBrandBusinessRules)
        {
            _mapper = mapper;
            _companyBrandRepository = companyBrandRepository;
            _companyBrandBusinessRules = companyBrandBusinessRules;
        }

        public async Task<GetByIdCompanyBrandResponse> Handle(GetByIdCompanyBrandQuery request, CancellationToken cancellationToken)
        {
            CompanyBrand? companyBrand = await _companyBrandRepository.GetAsync(predicate: cb => cb.Id == request.Id, cancellationToken: cancellationToken);
            await _companyBrandBusinessRules.CompanyBrandShouldExistWhenSelected(companyBrand);

            GetByIdCompanyBrandResponse response = _mapper.Map<GetByIdCompanyBrandResponse>(companyBrand);
            return response;
        }
    }
}