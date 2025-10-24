using Social.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Interface
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }
        IGroupRepository GroupRepository { get; }
        IUserRepository UserRepository { get; }

        IPageRepository PageRepository { get; }

        ICommentRepository CommentRepository { get; }
        IHashtagRepository HashtagRepository { get; }

        IGenericRepository<T> GenericRepository<T>() where T : class;
        Task<int> CompleteAsync();
    }
}
