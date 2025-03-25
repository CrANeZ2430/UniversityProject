using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Departments.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfigurations;

public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.DepartmentId);

        builder.Property(x => x.DepartmentId)
            .HasColumnOrder(1);

        builder.Property(x => x.Title)
            .HasMaxLength(30)
            .IsRequired()
            .HasColumnOrder(2);

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .IsRequired()
            .HasColumnOrder(3);

        builder.Property(x => x.FacultyId)
            .IsRequired()
            .HasColumnOrder(4);

        builder.HasOne(x => x.Faculty)
            .WithMany(x => x.Departments)
            .HasForeignKey(x => x.FacultyId)
            .IsRequired();

        builder.HasMany(x => x.Groups)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId);

        builder.Metadata
            .FindNavigation(nameof(Department.Faculty))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Department.Groups))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
