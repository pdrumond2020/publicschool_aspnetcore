using Microsoft.EntityFrameworkCore;
using PublicSchool.Domain.Entities;
using System;

namespace PublicSchool.Infra.Data.Context
{
    public class PublicSchoolContext : DbContext
    {
        public PublicSchoolContext(DbContextOptions options) : base(options)
        {
        }

        public PublicSchoolContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryPublicSchoolProvider");
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}