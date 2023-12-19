using SingerSong.Core.Abstracts.Entity;

namespace SingerSong.Domain.Identities;

public class User : Entity<Guid>, IStatus
{
    public User() { }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
        IsActive = true;
    }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid? RoleID { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? TokenExpiredTime { get; set; }
    public bool IsActive { get; set; }
    public Role Role { get; set; }
}

