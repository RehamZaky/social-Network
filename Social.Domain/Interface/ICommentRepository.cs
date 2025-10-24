using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Interface
{
    public interface ICommentRepository :IGenericRepository<Comment>
    {
        public Task<bool> HideAndShowComment(int commentId, bool hide);

        public Task<bool> ReplyComment(int commentId, Comment comment);
    }
}
