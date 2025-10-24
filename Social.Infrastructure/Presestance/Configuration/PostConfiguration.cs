using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Domain.Data;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Infrastructure.Presestance.Configuration
{
    public class PostConfiguration:IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Post");
            builder.Property(p=> p.Content).IsRequired();
            builder.Property(p=> p.IsHidden).HasDefaultValue(false);

            builder.HasMany<PostInteraction>().WithOne(p=> p.Posts).HasForeignKey(p=>p.PostId);

            builder.HasMany(s => s.PagePosts).WithOne(w => w.Posts).HasForeignKey(s => s.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.GroupPosts).WithOne(w => w.Posts).HasForeignKey(s => s.PostId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
