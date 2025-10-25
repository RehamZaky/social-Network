using Social.Application.DTO;
using Social.Domain.Data;
using Social.Domain.Entities;
using Social.Domain.Interface;

namespace Social.Application.Services.Interface
{
    public interface IPostService 
    {
        public Task<List<Posts>> GetAll();
        public Task<Posts> Post(PostDTO t);
        public Task<Posts> GetById(int id);

        public Task<Posts> Put(PostEditDTO t);
        public Task Delete(int id);

        public Task<List<Posts>> GetPostsByUserAsync(int userId);

        public Task<PostDTO> AddPostToPageAsync(int pageId, PostDTO postDTO);
        public Task<PostGroupResponseDTO> AddPostToGroupAsync(CreatePostGroupDTO postDTO);

        Task<PostInteraction> AddPostInteraction(PostInteractionDTO interactionDTO);


    }
}
