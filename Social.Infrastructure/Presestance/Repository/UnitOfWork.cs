
using Social.Application.Services.Interface;
using Social.Application.Services.Repository;
using Social.Domain.Interface;
using Social.Infrastructure.Presestance.Data;

namespace Social.Infrastructure.Presestance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private IPostRepository _postRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPageRepository _pageRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IHashtagRepository _hashtagRepository;
        private readonly IFriendRepository _friendRepository;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            // Add postRepo ??
        }

        public IPostRepository PostRepository => _postRepository ??= new PostRepository(_context);

        public IGroupRepository GroupRepository => _groupRepository ?? new GroupRepository(_context);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public IPageRepository PageRepository => _pageRepository ?? new PageRepository(_context);

        public ICommentRepository CommentRepository=> _commentRepository ?? new CommentRepository(_context);

        public IHashtagRepository HashtagRepository => _hashtagRepository ?? new HashtagRepository(_context);

        public IFriendRepository FriendRepository => _friendRepository ?? new FriendRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }
    }
}
