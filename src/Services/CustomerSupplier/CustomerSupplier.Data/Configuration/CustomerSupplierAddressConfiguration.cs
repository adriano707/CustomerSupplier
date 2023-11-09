using CustomerSupplier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerSupplier.Data.Configuration
{
    public class CustomerSupplierAddressConfiguration : IEntityTypeConfiguration<CustomerSupplierAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerSupplierAddress> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Road).HasColumnType("varchar(100)");
            builder.Property(c => c.District).HasColumnType("varchar(100)");
            builder.Property(c => c.City).HasColumnType("varchar(100)");
            builder.Property(c => c.State).HasColumnType("varchar(100)");
        }
    }
}
