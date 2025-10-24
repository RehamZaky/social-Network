using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Interface
{
    public interface IGroupRepository :IGenericRepository<Group>
    {
        public Task<List<Group>> GetUserGroups(int userId);

        public Task<Group> DeactivateGroup(int groupId, bool isActive);

    }
}
