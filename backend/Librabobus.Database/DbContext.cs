using System;
using Librabobus.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Librabobus.Database
{
    public class LibrabobusDbContext: DbContext
    {
        public LibrabobusDbContext(DbContextOptions<LibrabobusDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Librabobus");

            modelBuilder.ApplyConfiguration(new RecordConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SavedSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriprionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }

    }
}