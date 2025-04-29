using Application.Features.Regions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Regions.Commands.Create;

public class CreateRegionCommand : IRequest<CreatedRegionResponse>
{
    public required string Name { get; set; }
    public required SavedTypeEnum Type { get; set; }

    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, CreatedRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        private readonly RegionBusinessRules _regionBusinessRules;

        public CreateRegionCommandHandler(IMapper mapper, IRegionRepository regionRepository,
                                         RegionBusinessRules regionBusinessRules)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
            _regionBusinessRules = regionBusinessRules;
        }

        public async Task<CreatedRegionResponse> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            Region region = _mapper.Map<Region>(request);

            await _regionRepository.AddAsync(region);

            CreatedRegionResponse response = _mapper.Map<CreatedRegionResponse>(region);
            return response;
        }
    }
}