using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Infrastructure.Presestance.Configuration
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {

        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Info).IsRequired();

            builder.HasMany(s => s.Members)
                .WithOne(m => m.Page)
                .HasForeignKey(s=> s.PageId);
        }
    }
}
