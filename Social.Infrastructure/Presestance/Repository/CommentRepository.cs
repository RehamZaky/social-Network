using Microsoft.EntityFrameworkCore;
using Social.Domain.Entities;
using Social.Domain.Interface;
using Social.Infrastructure.Presestance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Infrastructure.Presestance.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CommentRepository(ApplicationDBContext applicationDB) : base(applicationDB)
        {
            _dbContext = applicationDB;
        }

        public async Task<bool> HideAndShowComment(int commentId, bool hide)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);
            if(comment == null)
            {
                return false;
             }

            comment.IsHidden = hide;
            await _dbContext.SaveChangesAsync(); 
            return true;
        }

        public async Task<bool> ReplyComment(int commentId, Comment comment)
        {
            var responseComment = _dbContext.Comments.Include(i => i.Post).FirstOrDefault(i=> i.Id == commentId);
            
            if(comment != null)
            {
                comment.ParentComment = responseComment;
                comment.Post = responseComment.Post;
               await _dbContext.Comments.AddAsync(comment);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
