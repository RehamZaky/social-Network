using AutoMapper;
using Social.Application.DTO;
using Social.Application.Services.Interface;
using Social.Domain.Entities;
using Social.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Service
{
    public class PageService : IPageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPageRepository _pageRepository;
        public PageService(IUnitOfWork unitOfWork, IMapper mapper,IPageRepository pageRepository) { 
        
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pageRepository = pageRepository;
        }

        public async Task<List<Page>> GetAll()
        {
            return await _unitOfWork.GenericRepository<Page>().GetAll();
        }

        public async Task<PageDTO> Post(PageDTO t)
        {
            var Page = _mapper.Map<Page>(t);
            var PageResponse = await _unitOfWork.GenericRepository<Page>().Create(Page);
            return _mapper.Map<PageDTO>(PageResponse);
        }

        public async Task<PageDTO> Put(PageEditDTO t)
        {
            var Page = _mapper.Map<Page>(t);
            var PageResponse = await _unitOfWork.GenericRepository<Page>().Update(Page);
            return _mapper.Map<PageDTO>(PageResponse);
        }
        public async Task Delete(int id)
        {
            await _unitOfWork.GenericRepository<Page>().Delete(id);
        }

        public async Task<Page> GetById(int id)
        {
            return await _unitOfWork.GenericRepository<Page>().GetById(id);

        }

        public async Task<List<Page>> GetPagesByUserAsync(int userId)
        {
            return await _pageRepository.GetUserPages(userId);
        }

        public async Task<Page> DeactivatePage(int pageId, bool isActive)
        {
            return await _pageRepository.DeactivatePage(pageId, isActive);
        }
    }
}
