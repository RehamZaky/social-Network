using AutoMapper;
using Social.Application.DTO;
using Social.Application.Services.Interface;
using Social.Domain.Data;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Service
{
    public class HashtagService : IHashtagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HashtagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HashtagDto>> GetAllAsync()
        {
            var hashtags = await _unitOfWork.GenericRepository<Hashtag>().GetAll();
            return _mapper.Map<IEnumerable<HashtagDto>>(hashtags);
        }

        public async Task<HashtagDto> GetByNameAsync(string hashtag)
        {
            var hashtagResponse = await _unitOfWork.HashtagRepository.GetByNameAsync(hashtag);
            return _mapper.Map<HashtagDto>(hashtagResponse);
        }

        public async Task<HashtagDto> CreateAsync(HashtagDto dto)
        {
            var entity = _mapper.Map<Hashtag>(dto);
            await _unitOfWork.GenericRepository<Hashtag>().Post(entity);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<HashtagDto>(entity);
        }
        public async Task<HashtagDto> UpdateAsync(UpdateHashtagDto dto)
        {
            var entity = _mapper.Map<Hashtag>(dto);
            await _unitOfWork.GenericRepository<Hashtag>().Put(entity);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<HashtagDto>(entity);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.GenericRepository<Hashtag>().Delete(id);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<HashtagPostDTO> AddHashtagToPost(string hashtag, int postId)
        {
           var post = await _unitOfWork.HashtagRepository.AddHashtagToPost(hashtag, postId);
            return _mapper.Map<HashtagPostDTO>(post);    
        }

        public async Task<List<PostDTO>> GetAllPostsOfHashtagAsync(string hashtag)
        {
            var response = await _unitOfWork.HashtagRepository.GetAllPostsOfHashtagAsync(hashtag);
            if (response == null) throw new KeyNotFoundException();
           return _mapper.Map<List<PostDTO>>(response);
        }
    }

}
