using Application.Features.Countries.Constants;
using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Countries.Commands.Delete;

public class DeleteCountryCommand : IRequest<DeletedCountryResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCountries"];

    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, DeletedCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly CountryBusinessRules _countryBusinessRules;

        public DeleteCountryCommandHandler(IMapper mapper, ICountryRepository countryRepository,
                                         CountryBusinessRules countryBusinessRules)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _countryBusinessRules = countryBusinessRules;
        }

        public async Task<DeletedCountryResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            Country? country = await _countryRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _countryBusinessRules.CountryShouldExistWhenSelected(country);

            await _countryRepository.DeleteAsync(country!);

            DeletedCountryResponse response = _mapper.Map<DeletedCountryResponse>(country);
            return response;
        }
    }
}