namespace SingerSong.Persistence.EntityTypeConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.RoleTitle).IsUnique();

        builder.HasData(new Role
        {
            Id = new Guid("279b1e39aca544dbaacbecd57ae4831e"),
            RoleTitle = "User",
            Description = "This role is for standard users."
        });
    }
}

