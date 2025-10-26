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
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasKey(x => new { x.FriendId, x.UserId});
            builder.HasOne(s=> s.User).WithMany(k=> k.Friends).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);  
            builder.HasOne(s=> s.FriendUser).WithMany(k=> k.FriendsOfUser).HasForeignKey(x=>x.FriendId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
