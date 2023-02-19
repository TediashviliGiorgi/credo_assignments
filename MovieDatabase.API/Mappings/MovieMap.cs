using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.DB.Entities;

namespace MovieDatabase.API.Mappings
{
    public class MovieMap : IEntityTypeConfiguration<MovieEntity>
    {
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).HasMaxLength(200).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(2000).IsRequired();
            builder.Property(t => t.Director).IsRequired();
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
        }
    }
}
