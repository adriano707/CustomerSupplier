using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerSupplier.Data.Configuration
{
    public class CustomerSupplierConfiguration : IEntityTypeConfiguration<Domain.Entities.CustomerSupplier>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.CustomerSupplier> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("varchar(100)");

            builder.HasMany(c => c.AddressList)
                .WithOne()
                .HasForeignKey(ca => ca.CustomerSupplierId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(c => c.ContactList)
                .WithOne()
                .HasForeignKey(cc => cc.CustomerSupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
