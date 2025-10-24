using Social.Application.DTO;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Interface
{
    public interface IGroupService
    {
        public Task<List<Group>> GetAll();
        public Task<GroupDTO> Post(GroupDTO t);
        public Task<GroupDTO> GetById(int id);

        public Task<GroupDTO> Put(GroupEditDTO t);
        public Task Delete(int id);

        public Task<List<Group>> GetUserGroups(int userId);

        public Task<Group> DeactivateGroup(int groupId, bool isActive);


    }
}
