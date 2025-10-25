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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Info).IsRequired();

            builder.HasMany(s => s.GroupMembers)
                .WithOne(m => m.Group)
                .HasForeignKey(s => s.GroupId); //restrict

            builder.HasMany(s => s.GroupPosts)
                .WithOne(r => r.Group)
                .HasForeignKey(s => s.GroupId);

            
        }
    }
}
