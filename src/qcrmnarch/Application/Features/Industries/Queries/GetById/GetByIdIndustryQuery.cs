using Application.Features.Industries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Industries.Queries.GetById;

public class GetByIdIndustryQuery : IRequest<GetByIdIndustryResponse>
{
    public int Id { get; set; }

    public class GetByIdIndustryQueryHandler : IRequestHandler<GetByIdIndustryQuery, GetByIdIndustryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndustryRepository _industryRepository;
        private readonly IndustryBusinessRules _industryBusinessRules;

        public GetByIdIndustryQueryHandler(IMapper mapper, IIndustryRepository industryRepository, IndustryBusinessRules industryBusinessRules)
        {
            _mapper = mapper;
            _industryRepository = industryRepository;
            _industryBusinessRules = industryBusinessRules;
        }

        public async Task<GetByIdIndustryResponse> Handle(GetByIdIndustryQuery request, CancellationToken cancellationToken)
        {
            Industry? industry = await _industryRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _industryBusinessRules.IndustryShouldExistWhenSelected(industry);

            GetByIdIndustryResponse response = _mapper.Map<GetByIdIndustryResponse>(industry);
            return response;
        }
    }
}