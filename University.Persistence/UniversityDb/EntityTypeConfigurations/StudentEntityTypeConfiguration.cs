using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Core.Domain.Students.Models;

namespace University.Persistence.UniversityDb.EntityTypeConfigurations;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.StudentId);

        builder.Property(x => x.StudentId)
            .HasColumnOrder(1);

        builder.Property(x => x.FirstName)
            .HasMaxLength(30)
            .IsRequired()
            .HasColumnOrder(2);

        builder.Property(x => x.LastName)
            .HasMaxLength(30)
            .IsRequired()
            .HasColumnOrder(3);

        builder.Property(x => x.MiddleName)
            .HasMaxLength(30)
            .IsRequired(false)
            .HasColumnOrder(4);

        builder.Property(x => x.Email)
            .HasMaxLength(40)
            .IsRequired()
            .HasColumnOrder(5);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired()
            .HasColumnOrder(6);

        builder.Property(x => x.GroupId)
            .IsRequired()
            .HasColumnOrder(7);

        builder.HasOne(x => x.Group)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.GroupId);

        builder.Metadata
            .FindNavigation(nameof(Student.Group))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
