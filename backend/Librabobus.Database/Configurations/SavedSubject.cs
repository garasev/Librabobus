using Librabobus.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librabobus.Database.Configurations
{
    public class SavedSubjectConfiguration: IEntityTypeConfiguration<SavedSubject>
    {
        public void Configure(EntityTypeBuilder<SavedSubject> builder)
        {
            builder.HasIndex(savedSubject => savedSubject.UserId).IsUnique();
            builder.HasIndex(savedSubject => savedSubject.SubjectId).IsUnique();

            builder.HasKey(savedSubject => new {
                savedSubject.UserId,
                savedSubject.SubjectId
            });
            
            builder.Property(savedSubject => savedSubject.UserId).IsRequired();
            builder.Property(savedSubject => savedSubject.SubjectId).IsRequired();
        }
    }
}