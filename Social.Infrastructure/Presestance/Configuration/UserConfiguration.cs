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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.HasKey(x => x.Id);

            // Optional: Add a unique constraint on Email
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

            builder.HasMany(s=> s.Posts)
                .WithOne(p=> p.Users)
                .HasForeignKey(p => p.userId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(s => s.pageMembers).WithOne(w => w.User).HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s=> s.groupMembers).WithOne(w=> w.User).HasForeignKey(s => s.UserId) 
                .OnDelete(DeleteBehavior.NoAction);    
        }
    }
}
