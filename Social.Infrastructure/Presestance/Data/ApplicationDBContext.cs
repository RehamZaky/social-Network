
using Microsoft.EntityFrameworkCore;
using Social.Domain.Data;
using Social.Domain.Entities;
using System.Reflection.Emit;

namespace Social.Infrastructure.Presestance.Data
{
    public class ApplicationDBContext : DbContext //IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

            builder.Entity<GroupMember>().HasKey(j => new {j.GroupId, j.UserId });
            builder.Entity<PageMember>().HasKey(j => new {j.PageId, j.UserId});
            builder.Entity<GroupPosts>().HasKey(j => new { j.GroupId, j.PostId});
            builder.Entity<PagePosts>().HasKey(j=> new {j.PageId,j.PostId});


            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Hashtag> Hashtags { get; set; }    

        public DbSet<PostInteraction> PostInteraction { get; set; }

        public DbSet<Media> Media { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupMember> GroupMembers { get; set; }

        public DbSet<GroupPosts> GroupPosts { get; set; }

        public DbSet<PageMember> PageMembers { get; set; }

        public DbSet<PagePosts> PagePosts { get; set; } 


    }
}
