using Social.Application.DTO;
using Social.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Interface
{
    public interface IHashtagService
    {
        Task<IEnumerable<HashtagDto>> GetAllAsync();
        Task<HashtagDto> GetByIdAsync(int id);
        Task<HashtagDto> CreateAsync(HashtagDto dto);
        Task<HashtagDto> UpdateAsync(UpdateHashtagDto dto);
        Task<bool> DeleteAsync(int id);

        Task<Posts> AddHashtagToPost(string hashtag,PostEditDTO dto);
    }

}
