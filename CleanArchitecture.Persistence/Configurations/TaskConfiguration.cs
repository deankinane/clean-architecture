using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArchitecture.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.Property(x => x.Notes)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(x => x.SoftDeleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => x.SoftDeleted == false);
        }
    }
}
