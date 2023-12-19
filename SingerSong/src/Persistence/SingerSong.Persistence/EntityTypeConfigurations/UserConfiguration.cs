namespace SingerSong.Persistence.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.HasData(new User
        {
            Id = new Guid("9a82361b7fe14155a2205a637fc60b46"),
            Email = "johndoe@mail.com",
            Password = "john123",
            RoleID = new Guid("279b1e39aca544dbaacbecd57ae4831e")
        });
    }
}

