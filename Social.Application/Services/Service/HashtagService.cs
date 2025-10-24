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

        public async Task<HashtagDto> GetByIdAsync(int id)
        {
            var hashtag = await _unitOfWork.HashtagRepository.GetById(id);
            return _mapper.Map<HashtagDto>(hashtag);
        }

        public async Task<HashtagDto> CreateAsync(HashtagDto dto)
        {
            var entity = _mapper.Map<Hashtag>(dto);
            await _unitOfWork.HashtagRepository.Post(entity);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<HashtagDto>(entity);
        }

        public async Task<HashtagDto> UpdateAsync(UpdateHashtagDto dto)
        {
            var existing = await _unitOfWork.HashtagRepository.GetById(dto.Id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            await _unitOfWork.HashtagRepository.Put(existing);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<HashtagDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.GenericRepository<Hashtag>().Delete(id);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<Posts> AddHashtagToPost(string hashtag, PostEditDTO dto)
        {
           var post = _mapper.Map<Posts>( dto);
           return await _unitOfWork.HashtagRepository.AddHashtagToPost(hashtag, post);

        }
    }

}
