using SingerSong.Core.Abstracts.Entity;

namespace SingerSong.Domain.Identities;

public class Role : Entity<Guid>, IStatus
{
    public Role()
    {
        Users = new HashSet<User>();
    }

    public Role(string roleTitle, string description)
    {
        RoleTitle = roleTitle;
        Description = description;
        Users = new HashSet<User>();
        IsActive = true;
    }

    public string RoleTitle { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public ICollection<User> Users { get; set; }
}

