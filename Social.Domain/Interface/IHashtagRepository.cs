using Social.Domain.Data;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Interface
{
    public interface IHashtagRepository : IGenericRepository<Hashtag>
    {
        Task<Hashtag> GetByNameAsync(string name);
        Task<Posts> AddHashtagToPost(string hashtag, Posts post);


    }

}
