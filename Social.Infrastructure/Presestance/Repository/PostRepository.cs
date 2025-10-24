using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using Social.Application.Services.Interface;
using Social.Domain.Data;
using Social.Domain.Entities;
using Social.Domain.Interface;
using Social.Infrastructure.Presestance.Data;

namespace Social.Infrastructure.Presestance.Repository
{
    public class PostRepository : GenericRepository<Posts>, IPostRepository
    {
        private readonly ApplicationDBContext _applicationDB;
        public PostRepository(ApplicationDBContext applicationDB) : base(applicationDB)
        {
            _applicationDB = applicationDB;
        }

        public async Task<PostInteraction> AddPostInteraction(PostInteraction interaction)
        {
            var post = _applicationDB.Posts.Find(interaction.PostId);
            if (post == null)
            {
                return null;
            }
            await _applicationDB.PostInteraction.AddAsync(interaction);
            await _applicationDB.SaveChangesAsync();
            return interaction;
        }

        public async Task<Posts> AddPostToGroupAsync(int groupId, Posts posts)
        {
            var group = _applicationDB.Groups.Find(groupId);
            if (group == null) return null;

            var groupPost = new GroupPosts() { GroupId =  groupId ,Posts = posts, Status =0 };
            await _applicationDB.GroupPosts.AddAsync(groupPost);
            await _applicationDB.SaveChangesAsync();
            return posts;
        }

        public async Task<Posts> AddPostToPageAsync(int pageId, Posts Post)
        {
            var page = _applicationDB.Pages.Find(pageId);
            if (page == null)
            {
                return null;
            }

            var pagePost = new PagePosts() { PageId = pageId, Posts = Post, Status = 0 };

             await _applicationDB.PagePosts.AddAsync(pagePost);
            await _applicationDB.SaveChangesAsync();
            return Post;
        }

        public async Task<List<Posts>> GetPostsByUserAsync(int userId)
        {
           return await _applicationDB.Posts.Where(s => s.userId == userId).ToListAsync();
        }

        //public async Task<List<Posts>> GetPostsOfHashtagName(string hashtag)
        //{
        //    var hashtagResult = await _applicationDB.Hashtags.FirstOrDefaultAsync(h => h.Name.ToLower() == hashtag.ToLower());
        //    _applicationDB.has
        //}
    }
}