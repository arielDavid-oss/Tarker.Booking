using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity>entityBuilder)
        {
            entityBuilder.HasKey(x => x.CustomerId);
            entityBuilder.Property(x => x.FullName).IsRequired();
            entityBuilder.Property(x => x.DocumentNumber).IsRequired();

            entityBuilder.HasMany(x => x.Bookings)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId);

        }
    }
}
