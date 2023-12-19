using SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Models;

namespace SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Validation;

internal class InsertRoleValidator : AbstractValidator<InsertRoleRequest>
{
    public InsertRoleValidator()
    {
        RuleFor(x => x.RoleTitle).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Length(2, 15).WithMessage("{PropertyName} should be between 2 and 15 characters!");

        RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("{PropertyName} is required!")
            .Length(5, 50).WithMessage("{PropertyName} should be between 5 and 50 characters!");
    }
}

