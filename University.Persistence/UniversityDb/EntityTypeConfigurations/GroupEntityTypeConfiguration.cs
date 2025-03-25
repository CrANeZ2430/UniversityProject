using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Groups.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfigurations;

public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.GroupId);

        builder.Property(x => x.GroupId)
            .HasColumnOrder(1);

        builder.Property(x => x.Name)
            .HasMaxLength(30)
            .IsRequired()
            .HasColumnOrder(2);

        builder.Property(x => x.MaxStudents)
            .IsRequired()
            .HasColumnOrder(3);

        builder.Property(x => x.DepartmentId)
            .IsRequired()
            .HasColumnOrder(4);

        builder.HasOne(x => x.Department)
            .WithMany(x => x.Groups)
            .HasForeignKey(x => x.DepartmentId);

        builder.Metadata
            .FindNavigation(nameof(Group.Department))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
