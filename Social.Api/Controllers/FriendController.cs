using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Application.DTO;
using Social.Application.Exception;
using Social.Application.Services.Interface;
using Social.Application.Services.Repository;

namespace Social.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        public FriendController(IFriendService friendService) {
        _friendService = friendService;
        }

        [HttpGet("GetAllUserFriends")]
        public async Task<IActionResult> GetAll(int userId)
        {
            try
            {
                var result = await _friendService.GetAllFriendsOfUser(userId);
                return Ok(ApiResponse<List<FriendDetailsDTO>>.SuccessResponse(result.ToList(), "Get Friends Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<FriendDetailsDTO>.FailResponse("Error getting Friends", new[] { ex.Message }));
            }
        }

        [HttpPost("SendFriendShip")]
        public async Task<IActionResult> SendFriendShip([FromBody] FriendDTO dto)
        {
            try
            {
                var result = await _friendService.CreateFriendRequest(dto);
                return Ok(ApiResponse<FriendDTO>.SuccessResponse(result, "Send friend request Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<FriendDTO>.FailResponse("Error Sending friend request", new[] { ex.Message }));
            }
        }

        [HttpPut("UpdateFriendship")]
        public async Task<IActionResult> Update(FriendDTO friendDTO)
        {
            try
            {
                var result = await _friendService.UpdateFriendshipStatus(friendDTO);
                return Ok(ApiResponse<FriendDTO>.SuccessResponse(result, "Updated Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<FriendDTO>.FailResponse("Error Saving friendship", new[] { ex.Message }));

            }
        }

        [HttpDelete("{userId}/{friendId}")]
        public async Task<IActionResult> Delete(int userId, int friendId)
        {
            try
            {
                await _friendService.DeleteFriendReq(userId, friendId);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<FriendDTO>.FailResponse("Error Delete Friendship", new[] { ex.Message }));

            }
        }
    }
}
