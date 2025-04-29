
using FluentValidation;
using Application.Features.ProductImages.Commands.Update;
namespace Application.Features.ProductImages.Commands.Update;

public class UpdateProductImageCommandValidator : AbstractValidator<UpdateProductImageCommand>
{
    public UpdateProductImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Product).NotEmpty();
        RuleFor(c => c.FilePath).NotEmpty();
        RuleFor(c => c.FileName).NotEmpty();
    }
}