using Application.Features.Roles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Roles.Commands.Create;

public class CreateRoleCommand : IRequest<CreatedRoleResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRoles"];

    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreatedRoleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly RoleBusinessRules _roleBusinessRules;

        public CreateRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository,
                                         RoleBusinessRules roleBusinessRules)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<CreatedRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Role role = _mapper.Map<Role>(request);

            await _roleRepository.AddAsync(role);

            CreatedRoleResponse response = _mapper.Map<CreatedRoleResponse>(role);
            return response;
        }
    }
}