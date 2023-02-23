using GPACalculator.API.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPACalculator.API.DB.Mapping
{
    public class GradeMap : IEntityTypeConfiguration<GradeEntity>
    {
        public void Configure(EntityTypeBuilder<GradeEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder
                .HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId);
                
            
            builder
                .HasOne(t => t.Subject)
                .WithMany()
                .HasForeignKey(t => t.SubjectId);
        }
    }
}
