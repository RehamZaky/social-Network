using Microsoft.EntityFrameworkCore;
using Social.Domain.Data;
using Social.Domain.Entities;
using Social.Domain.Interface;
using Social.Infrastructure.Presestance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Infrastructure.Presestance.Repository
{
    public class HashtagRepository : GenericRepository<Hashtag>, IHashtagRepository
    {
        private readonly ApplicationDBContext _context;

        public HashtagRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Hashtag> GetByNameAsync(string name)
        {
            return await _context.Hashtags.FirstOrDefaultAsync(h => h.Name.ToLower() == name.ToLower());
        }

        public async Task<Posts> AddHashtagToPost(string hashtag, int postId)
        {
            var postResponse = await _context.Posts.Include(p=> p.Hashtags).FirstOrDefaultAsync(i=> i.Id == postId);
            if(postResponse != null)
            {
                var HashtagResponse = await GetByNameAsync(hashtag);
                if(HashtagResponse == null)
                {
                    // create the hashtag
                    HashtagResponse = await Create(new Hashtag() { Name = hashtag ,UserId = postResponse.userId, CreatedDate = DateTime.UtcNow});
                }
                 postResponse.Hashtags.Add(HashtagResponse);
                
                await _context.SaveChangesAsync();
                return postResponse;
            }
            return null;
        }

        public async Task<List<Posts>> GetAllPostsOfHashtagAsync(string hashtag)
        {
            var hashtagResponse = await _context.Hashtags.Include(h=> h.Posts).FirstOrDefaultAsync(h => h.Name.ToLower() == hashtag.ToLower());

            if(hashtagResponse == null) { return null; }
           return hashtagResponse.Posts.ToList();
        }
    }

}
