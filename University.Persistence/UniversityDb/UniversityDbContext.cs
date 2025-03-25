﻿using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Models;

namespace University.Persistence.UniversityDb;

public class UniversityDbContext(
    DbContextOptions<UniversityDbContext> options) 
    : DbContext(options)
{
    public static string UniversityMigrationHistory = "__UniMigrationHistory";
    public static string UniversityDbSchema = "university";

    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(UniversityDbSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDbContext).Assembly);
    }
}
