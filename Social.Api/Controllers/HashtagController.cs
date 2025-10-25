using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Application.DTO;
using Social.Application.Exception;
using Social.Application.Services.Interface;
using Social.Domain.Data;
using Social.Domain.Entities;

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
            try { 
            var result = await _service.GetAllAsync();
            return Ok(ApiResponse<List<HashtagDto>>.SuccessResponse(result.ToList(), "Get Hashtags Successfully"));
             }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<HashtagDto>.FailResponse( "Error getting hashtags",new[] { ex.Message }));
            }
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var result = await _service.GetByNameAsync(name);
                if (result == null) return NotFound();
                return Ok(ApiResponse<HashtagDto>.SuccessResponse( result, "Get Hashtag Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<HashtagDto>.FailResponse("Error getting hashtag", new[] { ex.Message }));

            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HashtagDto dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);
                return Ok(ApiResponse<HashtagDto>.SuccessResponse( result,"Create Hashtag Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<HashtagDto>.FailResponse("Error Creating hashtag", new[] {ex.Message}));
            }
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
        public async Task<IActionResult> AddHashtagToPost(string hashtag, int postId)
        {
            try
            {
                var result = await _service.AddHashtagToPost(hashtag, postId);
                if (result == null) return NotFound();
                return Ok(ApiResponse<HashtagPostDTO>.SuccessResponse( result,"Hashtag added to the post Successfully"));
            }
            catch (Exception ex) {
                return BadRequest(ApiResponse<HashtagDto>.FailResponse("Error Adding hashtag", new[] { ex.Message }));
            }
        }

        [HttpGet("GetAllPostsOfHashtag")]
        public async Task<IActionResult> GetAllPostsOfHashtag(string hashtag)
        {
            try
            {
                var result = await _service.GetAllPostsOfHashtagAsync(hashtag);
                if (result == null) return NotFound();
                return Ok(ApiResponse<List<PostDTO>>.SuccessResponse(result, "Hashtag added to the post Successfully"));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(ApiResponse<PostDTO>.FailResponse("Hashtag Not found",new[] {e.Message}));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<PostDTO>.FailResponse("Error Adding hashtag", new[] { ex.Message }));
            }
        }
    }

}
