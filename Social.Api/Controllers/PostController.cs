using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Application.DTO;
using Social.Application.Exception;
using Social.Application.Services.Interface;
using Social.Application.Validation;
using Social.Domain.Data;
using Social.Domain.Entities;

namespace Social.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private PostValidation postValidation;
        public PostController(IPostService postService)
        {
            _postService = postService;
            postValidation = new PostValidation();
        }

        [HttpGet("GetPosts")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _postService.GetAll();
                return Ok(ApiResponse<List<Posts>>.SuccessResponse(result, "Get All Posts Successfully"));
            }
            catch (Exception ex) {
                return BadRequest(ApiResponse<List<Posts>>.FailResponse("Error getting Posts", new[] { ex.Message}));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostDTO postDTO)
        {
            try
            {
                var postValidate = postValidation.Validate(postDTO);
                if (postValidate.IsValid)
                {
                    var result = await _postService.Post(postDTO);
                    return Ok(ApiResponse<Posts>.SuccessResponse(result, "Post added Successfully "));
                }
                else
                {
                    List<string> errors = new List<string>();
                    foreach (var error in postValidate.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    return BadRequest(ApiResponse<Posts>.FailResponse("Not Validate", errors));

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Posts>.FailResponse("Error Saving Post", new[] { ex.Message }));

            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PostEditDTO postDTO)
        {
            try { 
                var result = await _postService.Put(postDTO);
                return Ok(ApiResponse<Posts>.SuccessResponse(result,"Updated Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Posts>.FailResponse("Error Saving Post", new[] { ex.Message}));

            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int postId)
        {
            try
            {
                await _postService.Delete(postId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Posts>.FailResponse("Error Saving Post", new[] { ex.Message }));

            }
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _postService.GetById(id);
                return Ok(ApiResponse<Posts>.SuccessResponse(result,"Get Post Successfully"));
            }
             
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Posts>.FailResponse("Error Saving Post", new[] { ex.Message }));

            }
        }


        [HttpGet("GetUserPosts")]
        public async Task<IActionResult> GetPostsOfUser(int userId)
        {
            try
            {
                var result = await _postService.GetPostsByUserAsync(userId);
                return Ok(ApiResponse<List<Posts>>.SuccessResponse(result," Get all user Posts Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Posts>.FailResponse("Error Getting Posts", new[] { ex.Message }));

            }
        }

        [HttpPost("AddPostToPage/{PageId}")]
        public async Task<IActionResult> AddPostToPage(int PageId, PostDTO postDTO)
        {
            try
            {
                var result = await _postService.AddPostToPageAsync(PageId, postDTO);
                return Ok(ApiResponse<PostDTO>.SuccessResponse(result," Added Post Successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<Posts>.FailResponse("Page Not Found", new[] { ex.Message }));

            }
            catch (Exception e)
            {
                return BadRequest(ApiResponse<Posts>.FailResponse("Failed to add Post to the page", new[] { e.Message }));
            }
        }

        [HttpPost("AddPostToGroup")]
        public async Task<IActionResult> AddPostToGroup(PostGroupDTO postDTO)
        {
            try
            {
                var result = await _postService.AddPostToGroupAsync( postDTO);
                return Ok(ApiResponse<Posts>.SuccessResponse(result,"Add Post to the group Successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<Posts>.FailResponse("Group Not Found", new[] { ex.Message }));

            }
            catch (Exception e)
            {
                return BadRequest(ApiResponse<Posts>.FailResponse("Failed to add Post to the group", new[]{e.Message}));
            }
        }

        [HttpPost("AddPostInteraction")]
        public async Task<IActionResult> AddPostInteraction(PostInteractionDTO postInteractionDTO)
        {
            try
            {
                var result = await _postService.AddPostInteraction(postInteractionDTO);
                return Ok(ApiResponse<PostInteraction>.SuccessResponse(result,"Interact on Post Successfully"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<Posts>.FailResponse("Post Not Found", new[] { ex.Message }));

            }
            catch (Exception e)
            {
                return BadRequest(ApiResponse<Posts>.FailResponse("Failed to add Interact to the post", new[] { e.Message }));
            }
        }
    }
}
