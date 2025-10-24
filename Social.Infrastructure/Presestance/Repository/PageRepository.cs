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
    public class PageRepository : GenericRepository<Page>, IPageRepository
    {
        readonly ApplicationDBContext _dBContext;
        public PageRepository(ApplicationDBContext applicationDB) : base(applicationDB)
        {
            _dBContext = applicationDB;
        }

        public async Task<Page> DeactivatePage(int pageId, bool isActive)
        {
            var page = _dBContext.Pages.Find(pageId);
            if (page == null)
            {
                return null;
            }
            page.IsActive = isActive;
            await _dBContext.SaveChangesAsync();
            return page;
        }

        public async Task<List<Page>> GetUserPages(int userId)
        {
           return await _dBContext.Pages.Where(s => s.CreatedBy == userId).ToListAsync();
        }
    }
}
