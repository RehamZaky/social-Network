using AutoMapper;
using Social.Application.DTO;
using Social.Application.Services.Interface;
using Social.Domain.Data;
using Social.Domain.Entities;

namespace Social.Application.Services.Repository
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostService(IUnitOfWork unitOfWork ,IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Posts>> GetAll()
        {
           return await _unitOfWork.GenericRepository<Posts>().GetAll();
        }

        public async Task<Posts> GetById(int id)
        {
          return await _unitOfWork.GenericRepository<Posts>().GetById(id);
        }

        public async Task<Posts> Post(PostDTO t)
        {
           var post = _mapper.Map<Posts>(t);  
            return await _unitOfWork.GenericRepository<Posts>().Post(post);
        }

        public async Task<Posts> Put(PostEditDTO t)
        {
            var post = _mapper.Map<Posts>(t);
            return await _unitOfWork.GenericRepository<Posts>().Put(post);
        }
        public async Task Delete(int id)
        {
            await  _unitOfWork.GenericRepository<Posts>().Delete(id);
        }

       

        public async Task<List<Posts>> GetPostsByUserAsync(int userId)
        {
           return await _unitOfWork.PostRepository.GetPostsByUserAsync(userId);
        }

        public async Task<PostDTO> AddPostToPageAsync(int pageId, PostDTO postDTO)
        {
            var post = _mapper.Map<Posts>(postDTO);
            var response = await _unitOfWork.PostRepository.AddPostToPageAsync(pageId, post);
            if (response == null) { throw new KeyNotFoundException(); }
            return _mapper.Map<PostDTO>(response);
        }

        public async Task<Posts> AddPostToGroupAsync(PostGroupDTO postDTO)
        {
            var post = _mapper.Map<Posts>(postDTO);
            var response = await _unitOfWork.PostRepository.AddPostToGroupAsync(postDTO.GroupId, post);
            if (response == null) { throw new KeyNotFoundException(); }
            return response;
        }

        public async Task<PostInteraction> AddPostInteraction(PostInteractionDTO interactionDTO)
        {
            var interaction = _mapper.Map<PostInteraction>(interactionDTO);
            var response = await _unitOfWork.PostRepository.AddPostInteraction(interaction);
            if(response == null) { throw new KeyNotFoundException(); };
            return response;
        }
    }
}