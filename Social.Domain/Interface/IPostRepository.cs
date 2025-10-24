using Social.Domain.Data;
using Social.Domain.Entities;
using Social.Domain.Interface;

namespace Social.Application.Services.Interface
{
    public interface IPostRepository :IGenericRepository<Posts>
    {
        // additional 
        Task<List<Posts>> GetPostsByUserAsync(int userId);

        Task<Posts> AddPostToPageAsync(int pageId ,Posts Post);

        Task<Posts> AddPostToGroupAsync(int groupId,Posts posts);

        Task<PostInteraction> AddPostInteraction(PostInteraction interactionDTO);

     //   Task<List<Posts>> GetPostsOfHashtagName(string hashtag);

    }
}
