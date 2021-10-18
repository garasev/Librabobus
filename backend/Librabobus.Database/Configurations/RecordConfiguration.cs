using Librabobus.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librabobus.Database.Configurations
{
    public class RecordConfiguration: IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasIndex(record => record.Id).IsUnique();
            builder.HasKey(record => record.Id);
            builder.Property(record => record.Id).IsRequired();

            builder.Property(record => record.Name).IsRequired();
            builder.Property(record => record.Type).IsRequired();
            builder.Property(record => record.Content).IsRequired();
        }
    }
}