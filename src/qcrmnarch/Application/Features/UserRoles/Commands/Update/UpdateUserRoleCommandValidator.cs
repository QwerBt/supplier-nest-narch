using FluentValidation;

namespace Application.Features.UserRoles.Commands.Update;

public class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
{
    public UpdateUserRoleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
        RuleFor(c => c.RoleId).NotEmpty();
        RuleFor(c => c.Role).NotEmpty();
    }
}