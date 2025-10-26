using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Graph.Models.Security;
using Microsoft.Graph.Models;
using Social.Domain.Data;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Infrastructure.Presestance.Configuration
{
    public class HashtagConfiguration : IEntityTypeConfiguration<Hashtag>
    {
        public void Configure(EntityTypeBuilder<Hashtag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany<Posts>(x => x.Posts)
                .WithMany(p => p.Hashtags)
                .UsingEntity("PostHashtag");

            builder.HasOne(h=> h.User)
                .WithMany(p=> p.hashtags)
                .HasForeignKey(h => h.UserId);

          //  ,j => j.HasKey("PostId", "HashtagId"));

        }
    }
}
