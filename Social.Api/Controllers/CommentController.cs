using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Application.DTO;
using Social.Application.Services.Interface;

namespace Social.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _CommentService;
        public CommentController(ICommentService CommentService)
        {
            _CommentService = CommentService;
        }

        [HttpGet("GetAllComments")]
        public async Task<IActionResult> Get()
        {
            var result = await _CommentService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentDTO CommentDTO)
        {
            var result = await _CommentService.Post(CommentDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CommentEditDTO CommentDTO)
        {
            var result = await _CommentService.Put(CommentDTO);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int postId)
        {
            await _CommentService.Delete(postId);
            return Ok();
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _CommentService.GetById(id);
            return Ok(result);
        }

        [HttpPut("HideAndShowComment/{commentId}")]
        public async Task<IActionResult> HideAndShowComment(int commentId, [FromBody] bool hide)
        {
            var result = await _CommentService.HideAndShowComment(commentId, hide);
            return Ok(result);
        }


        [HttpPost("ReplyComment")]
        public async Task<IActionResult> ReplyComment( [FromBody] ReplyDTO commentDTO)
        {
            var result = await _CommentService.ReplyComment( commentDTO);
            return Ok(result);
        }
    }

 }
