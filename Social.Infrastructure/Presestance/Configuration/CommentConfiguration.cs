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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e=> e.Content).IsRequired();

            builder.HasOne(e => e.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(b => b.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);
                // IsRequired(false);  Use .OnDelete(DeleteBehavior.Restrict) instead — cleaner and clearer EF behavior.

            builder.HasOne(e => e.User)
                .WithMany(s => s.Comments)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);



            builder.HasOne(e=> e.Post).WithMany(s => s.Comments).HasForeignKey(b => b.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
