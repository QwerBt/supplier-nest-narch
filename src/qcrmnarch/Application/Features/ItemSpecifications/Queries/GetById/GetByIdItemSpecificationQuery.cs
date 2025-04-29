using Application.Features.ItemSpecifications.Constants;
using Application.Features.ItemSpecifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ItemSpecifications.Constants.ItemSpecificationsOperationClaims;

namespace Application.Features.ItemSpecifications.Queries.GetById;

public class GetByIdItemSpecificationQuery : IRequest<GetByIdItemSpecificationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdItemSpecificationQueryHandler : IRequestHandler<GetByIdItemSpecificationQuery, GetByIdItemSpecificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemSpecificationRepository _itemSpecificationRepository;
        private readonly ItemSpecificationBusinessRules _itemSpecificationBusinessRules;

        public GetByIdItemSpecificationQueryHandler(IMapper mapper, IItemSpecificationRepository itemSpecificationRepository, ItemSpecificationBusinessRules itemSpecificationBusinessRules)
        {
            _mapper = mapper;
            _itemSpecificationRepository = itemSpecificationRepository;
            _itemSpecificationBusinessRules = itemSpecificationBusinessRules;
        }

        public async Task<GetByIdItemSpecificationResponse> Handle(GetByIdItemSpecificationQuery request, CancellationToken cancellationToken)
        {
            ItemSpecification? itemSpecification = await _itemSpecificationRepository.GetAsync(predicate: isp => isp.Id == request.Id, cancellationToken: cancellationToken);
            await _itemSpecificationBusinessRules.ItemSpecificationShouldExistWhenSelected(itemSpecification);

            GetByIdItemSpecificationResponse response = _mapper.Map<GetByIdItemSpecificationResponse>(itemSpecification);
            return response;
        }
    }
}