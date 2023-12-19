namespace SingerSong.Persistence.EntityTypeConfigurations;

public class SingerConfiguration : IEntityTypeConfiguration<Singer>
{
    public void Configure(EntityTypeBuilder<Singer> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.SingerName).IsUnique(true);
        builder.HasMany<Album>(a => a.Albums).WithOne(s => s.Singer).HasForeignKey(s => s.SingerID);

        builder.HasData(new Singer
        {
            Id = new Guid("ee841df3532c4a788dfd9c3eac5c1d4e"),
            SingerType = SingerType.Group,
            MusicStyle = MusicStyle.HeavyMetal,
            SingerName = "Metallica",
            SingerAbout = "Metallica is an American heavy metal band. The band was formed " +
            "in 1981 in Los Angeles by vocalist and guitarist James Hetfield and drummer Lars Ulrich, " +
            "and has been based in San Francisco for most of its career.",
            Location = "USA"
        });
    }
}

