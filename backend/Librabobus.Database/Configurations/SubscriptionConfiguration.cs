using Librabobus.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librabobus.Database.Configurations
{
    public class SubscriptionConfiguration: IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasIndex(subscription => subscription.UserFromId).IsUnique();
            builder.HasIndex(subscription => subscription.UserToId).IsUnique();

            builder.HasKey(subscription => new {
                subscription.UserFromId,
                subscription.UserToId
            });
            
            builder.Property(subscription => subscription.UserFromId).IsRequired();
            builder.Property(subscription => subscription.UserToId).IsRequired();
        }
    }
}