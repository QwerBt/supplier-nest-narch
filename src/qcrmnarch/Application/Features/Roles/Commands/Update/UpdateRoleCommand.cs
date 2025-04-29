using Application.Features.Roles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Roles.Commands.Update;

public class UpdateRoleCommand : IRequest<UpdatedRoleResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRoles"];

    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdatedRoleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly RoleBusinessRules _roleBusinessRules;

        public UpdateRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository,
                                         RoleBusinessRules roleBusinessRules)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<UpdatedRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            Role? role = await _roleRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _roleBusinessRules.RoleShouldExistWhenSelected(role);
            role = _mapper.Map(request, role);

            await _roleRepository.UpdateAsync(role!);

            UpdatedRoleResponse response = _mapper.Map<UpdatedRoleResponse>(role);
            return response;
        }
    }
}