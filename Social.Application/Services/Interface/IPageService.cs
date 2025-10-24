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
    public interface IPageService
    {
        public Task<List<Page>> GetAll();
        public Task<PageDTO> Post(PageDTO t);
        public Task<Page> GetById(int id);

        public Task<PageDTO> Put(PageEditDTO t);
        public Task Delete(int id);

        public Task<List<Page>> GetPagesByUserAsync(int userId);

        public Task<Page> DeactivatePage(int pageId, bool isActive);
    }
}
