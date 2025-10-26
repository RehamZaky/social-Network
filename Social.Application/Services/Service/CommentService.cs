using AutoMapper;
using Social.Application.DTO;
using Social.Application.Services.Interface;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
         _mapper = mapper;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _unitOfWork.GenericRepository<Comment>().GetAll();
        }

        public async Task<bool> HideAndShowComment(int commentId, bool hide)
        {
           return await _unitOfWork.CommentRepository.HideAndShowComment(commentId, hide);
        }

        public async Task<Comment> GetById(int id)
        {
            return await _unitOfWork.GenericRepository<Comment>().GetById(id);
        }

        public async Task<CommentDTO> Post(CommentDTO t)
        {
            var Comment = _mapper.Map<Comment>(t);
            var CommentResponse = await _unitOfWork.GenericRepository<Comment>().Create(Comment);
            return _mapper.Map<CommentDTO>(CommentResponse);
        }

        public async Task<CommentDTO> Put(CommentEditDTO t)
        {
            var Comment = _mapper.Map<Comment>(t);
            var CommentResponse = await _unitOfWork.GenericRepository<Comment>().Update(Comment);
            return _mapper.Map<CommentDTO>(CommentResponse);
        }
        public async Task Delete(int id)
        {
             await _unitOfWork.GenericRepository<Comment>().Delete(id);
        }

        public async Task<bool> ReplyComment(ReplyDTO commentDTO)
        {
            var comment = _mapper.Map<Comment>(commentDTO);
            var response = await _unitOfWork.CommentRepository.ReplyComment(commentDTO.CommentId, comment);
            if(!response)
            {
                throw new KeyNotFoundException();
            }
            return response;

        }
    }
}
