using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Application.DTO;
using Social.Application.Services.Interface;
using Social.Application.Services.Service;

namespace Social.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {

            private readonly IPageService _PageService;
            public PageController(IPageService PageService)
            {
                _PageService = PageService;
            }

            [HttpGet("GetAllPages")]
            public async Task<IActionResult> Get()
            {
                var result = await _PageService.GetAll();
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Add(PageDTO PageDTO)
            {
                var result = await _PageService.Post(PageDTO);
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> Update(PageEditDTO PageDTO)
            {
                var result = await _PageService.Put(PageDTO);
                return Ok(result);
            }

            [HttpDelete]
            public async Task<IActionResult> Delete(int postId)
            {
                await _PageService.Delete(postId);
                return Ok();
            }


            [HttpGet("GetById")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _PageService.GetById(id);
                return Ok(result);
            }

        [HttpGet("GetPagesOfUser")]
        public async Task<IActionResult> GetPagesOfUser(int id)
        {
            var result = await _PageService.GetPagesByUserAsync(id);
            return Ok(result);
        }


        [HttpPut("DeactivatePage/'{pageId}'/activate")]
        public async Task<IActionResult> DeactivateGroup(int pageId, [FromBody] bool isActive)
        {
            var result = await _PageService.DeactivatePage(pageId, isActive);
            return Ok(result);
        }

    }
}
