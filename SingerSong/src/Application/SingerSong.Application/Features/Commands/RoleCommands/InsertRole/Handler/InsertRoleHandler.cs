using SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Models;
using SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Validation;
using SingerSong.Domain.Identities;

namespace SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Handler;
public sealed class InsertRoleHandler : IRequestHandler<InsertRoleRequest, IDataResult<InsertRoleResponse>>
{
    private readonly IUnitOfWorkCommand _command;
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;

    public InsertRoleHandler(IUnitOfWorkCommand command, IUnitOfWorkQuery query, IMapper mapper)
    {
        _command = command;
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<InsertRoleResponse>> Handle(InsertRoleRequest request, CancellationToken cancellationToken)
    {
        InsertRoleValidator validator = new();
        var validationResult = validator.Validate(request);
        List<string> errors = new();
        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new DataResult<InsertRoleResponse>(errors, false);
        }
        var existRole = await _query.RoleQuery().AnyAsync(x => x.RoleTitle.Equals(request.RoleTitle));
        if (existRole) return new DataResult<InsertRoleResponse>("Already this role is exists!", false);

        Role role = _mapper.Map<Role>(request);
        _command.RoleCommand().Insert(role);
        await _command.SaveAsync();
        return new DataResult<InsertRoleResponse>(_mapper.Map<InsertRoleResponse>(role),"Role was created.");
    }
}

