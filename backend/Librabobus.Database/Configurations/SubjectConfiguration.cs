using Librabobus.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librabobus.Database.Configurations
{
    public class SubjectConfiguration: IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasIndex(subject => subject.Id).IsUnique();
            builder.HasKey(subject => subject.Id);
            builder.Property(subject => subject.Id).IsRequired();

            builder.Property(subject => subject.OwnerId).IsRequired();
            builder.Property(subject => subject.Name).IsRequired();
            builder.Property(subject => subject.Privat).IsRequired();

            builder.HasMany(subject => subject.Records)
                .WithOne(record => record.Subject!);
            
            builder.HasMany(subject => subject.SavedSubjects)
                .WithOne(savedSubject => savedSubject.Subject!);
        }
    }
}