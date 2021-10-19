using Librabobus.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librabobus.Database.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(user => user.Id).IsUnique();

            builder.HasKey(user => user.Id);
            
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.Login).IsRequired();
            builder.HasIndex(user => user.Login).IsUnique();
            builder.Property(user => user.Hash).IsRequired();
            builder.Property(user => user.Salt).IsRequired();
            
            builder.HasMany(user => user.Subscriptions)
                .WithOne(subscription => subscription.UserFrom!);
            
            builder.HasMany(user => user.Subscribers)
                .WithOne(subscription => subscription.UserTo!);
            
            builder.HasMany(user => user.SavedSubjects)
                .WithOne(savedSubject => savedSubject.User!);

        }
    }
}