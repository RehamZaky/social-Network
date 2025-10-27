using Social.Application.DTO;
using Social.Domain.Data;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Interface
{
    public interface ICommentService
    {
        public Task<List<CommentDTO>> GetAll(int postId);

        public Task<CommentDTO> Post(CommentDTO commentDTO);
        public Task<CommentDTO> Put(CommentEditDTO t);
        public Task<Comment> GetById(int id);

        public Task Delete(int id);

        public Task<bool> HideAndShowComment(int commentId, bool hide);

        public Task<CommentReplyDTO> ReplyComment(ReplyDTO commentDTO);

    }
}
