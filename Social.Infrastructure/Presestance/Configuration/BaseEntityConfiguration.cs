using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Domain.Entities;

namespace Social.Infrastructure.Presestance.Configuration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Base
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();  // increment

            builder.Property(e => e.CreatedDate)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.IsDeleted)
                   .HasDefaultValue(false);

            // Add updated date trigger logic in repositories if needed
        }
    }
}
