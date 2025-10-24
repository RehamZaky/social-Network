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

        public async Task<Posts> AddHashtagToPost(string hashtag, Posts post)
        {
            var postResponse = await _context.Posts.FirstOrDefaultAsync(i=> i.Id == post.Id);
            if(postResponse != null)
            {
                var HashtagResponse = await GetByNameAsync(hashtag);
                if(HashtagResponse != null)
                {
                    postResponse.Hashtags.Add(HashtagResponse);

                }
                else
                {  // create the hashtag
                    await Post(new Hashtag() { Name = hashtag ,UserId = post.userId, CreatedDate = DateTime.UtcNow});
                }
                await _context.SaveChangesAsync();
                return postResponse;
            }
            return null;
        }
    }

}
