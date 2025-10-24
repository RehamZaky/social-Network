using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Application.DTO;
using Social.Application.Services.Interface;

namespace Social.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashtagController : ControllerBase
    {
        private readonly IHashtagService _service;

        public HashtagController(IHashtagService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HashtagDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok( result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHashtagDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");

            var result = await _service.UpdateAsync(dto);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPut("AddHashtagToPost{hashtag}")]
        public async Task<IActionResult> AddHashtagToPost(string hashtag, PostEditDTO postDTO)
        {
            var result = await _service.AddHashtagToPost( hashtag,postDTO);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }

}
