using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Faculties.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfigurations;

public class FacultyEntityTypeConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.HasKey(x => x.FacultyId);

        builder.Property(x => x.FacultyId)
            .HasColumnOrder(1);

        builder.Property(x => x.Title)
            .HasMaxLength(30)
            .IsRequired()
            .HasColumnOrder(2);

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired()
            .HasColumnOrder(3);

        builder.HasMany(x => x.Departments)
            .WithOne(x => x.Faculty)
            .HasForeignKey(x => x.FacultyId)
            .IsRequired();

        builder.Metadata
            .FindNavigation(nameof(Faculty.Departments))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
