using Application.Features.Regions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Regions.Commands.Update;

public class UpdateRegionCommand : IRequest<UpdatedRegionResponse>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required SavedTypeEnum Type { get; set; }

    public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand, UpdatedRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        private readonly RegionBusinessRules _regionBusinessRules;

        public UpdateRegionCommandHandler(IMapper mapper, IRegionRepository regionRepository,
                                         RegionBusinessRules regionBusinessRules)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
            _regionBusinessRules = regionBusinessRules;
        }

        public async Task<UpdatedRegionResponse> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {
            Region? region = await _regionRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _regionBusinessRules.RegionShouldExistWhenSelected(region);
            region = _mapper.Map(request, region);

            await _regionRepository.UpdateAsync(region!);

            UpdatedRegionResponse response = _mapper.Map<UpdatedRegionResponse>(region);
            return response;
        }
    }
}