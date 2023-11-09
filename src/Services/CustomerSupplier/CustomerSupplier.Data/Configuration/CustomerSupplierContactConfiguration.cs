using CustomerSupplier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerSupplier.Data.Configuration
{
    public class CustomerSupplierContactConfiguration : IEntityTypeConfiguration<CustomerSupplierContact>
    {
        public void Configure(EntityTypeBuilder<CustomerSupplierContact> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Email).HasColumnType("varchar(100)");
            builder.Property(c => c.Phone).HasColumnType("varchar(14)");
        }
    }
}
