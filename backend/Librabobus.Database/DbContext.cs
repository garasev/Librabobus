using System;
using Librabobus.Database.Configurations;
using Librabobus.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Librabobus.Database
{
    public class LibrabobusDbContext: DbContext
    {
        public LibrabobusDbContext(DbContextOptions<LibrabobusDbContext> options) : base(options)
        {
        }
        
        public DbSet<Record>? Record { get; set; }
        public DbSet<User>? User { get; set; }
        public DbSet<SavedSubject>? SavedSubject { get; set; }
        public DbSet<Subscription>? Subscription { get; set; }
        public DbSet<Subject>? Subject { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Librabobus");

            modelBuilder.ApplyConfiguration(new RecordConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SavedSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }

    }
}