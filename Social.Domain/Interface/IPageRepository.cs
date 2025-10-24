using Social.Domain.Entities;

namespace Social.Domain.Interface
{
    public interface IPageRepository :IGenericRepository<Page>
    {
       public Task<List<Page>> GetUserPages(int userId);

        public Task<Page> DeactivatePage(int pageId, bool isActive);

    }
}
