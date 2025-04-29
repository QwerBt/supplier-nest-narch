using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;
using Application.Features.ProductImages.Constants;
using Application.Features.ProductImages.Rules;

namespace Application.Features.ProductImages.Commands.Update;

public class UpdateProductImageCommand : IRequest<UpdatedProductImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required int ProductId { get; set; }
    public required Product Product { get; set; }
    public required string FilePath { get; set; }
    public required string FileName { get; set; }

    public string[] Roles => [Admin, Write, ProductImagesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductImages"];

    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, UpdatedProductImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ProductImageBusinessRules _productImageBusinessRules;

        public UpdateProductImageCommandHandler(IMapper mapper, IProductImageRepository productImageRepository,
                                         ProductImageBusinessRules productImageBusinessRules)
        {
            _mapper = mapper;
            _productImageRepository = productImageRepository;
            _productImageBusinessRules = productImageBusinessRules;
        }

        public async Task<UpdatedProductImageResponse> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            ProductImage? productImage = await _productImageRepository.GetAsync(predicate: ii => ii.Id == request.Id, cancellationToken: cancellationToken);
            await _productImageBusinessRules.ProductImageShouldExistWhenSelected(productImage);
            productImage = _mapper.Map(request, productImage);

            await _productImageRepository.UpdateAsync(productImage!);

            UpdatedProductImageResponse response = _mapper.Map<UpdatedProductImageResponse>(productImage);
            return response;
        }
    }
}