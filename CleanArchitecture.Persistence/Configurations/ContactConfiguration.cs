using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(b => b.FirstName)
                .HasColumnName("ContactFirstName")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(b => b.LastName)
                .HasColumnName("ContactLastName")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(b => b.DateOfBirth)
                .IsRequired();
        }
    }
}
