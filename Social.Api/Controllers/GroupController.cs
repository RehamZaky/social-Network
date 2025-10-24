using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Application.DTO;
using Social.Application.Services.Interface;
using Social.Application.Services.Service;

namespace Social.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        
            private readonly IGroupService _groupService;
            public GroupController(IGroupService groupService)
            {
                _groupService = groupService;
            }

            [HttpGet("GetAll")]
            public async Task<IActionResult> Get()
            {
                var result = await _groupService.GetAll();
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> Add(GroupDTO GroupDTO)
            {
                var result = await _groupService.Post(GroupDTO);
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> Update(GroupEditDTO GroupDTO)
            {
                var result = await _groupService.Put(GroupDTO);
                return Ok(result);
            }

            [HttpDelete]
            public async Task<IActionResult> Delete(int groupId)
            {
                await _groupService.Delete(groupId);
                return Ok();
            }


            [HttpGet("GetById")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _groupService.GetById(id);
                return Ok(result);
            }


        [HttpGet("GetGroupsOfUser")]
        public async Task<IActionResult> GetPagesOfUser(int id)
        {
            var result = await _groupService.GetUserGroups(id);
            return Ok(result);
        }

        [HttpPut("DeactivateGroup/'{groupId}'/activate")]
        public async Task<IActionResult> DeactivateGroup(int groupId ,[FromBody] bool isActive)
        {
            var result = await _groupService.DeactivateGroup(groupId, isActive);
            return Ok(result);
        }

    }
}
