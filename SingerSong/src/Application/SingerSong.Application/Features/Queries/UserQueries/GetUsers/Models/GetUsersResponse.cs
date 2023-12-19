namespace SingerSong.Application.Features.Queries.UserQueries.GetUsers.Models;

public record GetUsersResponse
{
    public string Id { get; init; }
    public string Email { get; init; }
    public string Role { get; init; }
}

