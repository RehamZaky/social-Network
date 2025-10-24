using Microsoft.EntityFrameworkCore;
using Social.Domain.Entities;
using Social.Domain.Interface;
using Social.Infrastructure.Presestance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Infrastructure.Presestance.Repository
{
    public class GroupRepository : GenericRepository<Group>,IGroupRepository
    {
        readonly ApplicationDBContext _dBContext;
        public GroupRepository(ApplicationDBContext applicationDB) : base(applicationDB)
        {
            _dBContext = applicationDB;
        }

        public async Task<Group> DeactivateGroup(int groupId, bool isActive)
        {
            var group = _dBContext.Groups.Find(groupId);
            if(group == null)
            {
                return null;
            }
            group.IsActive = isActive;
            await _dBContext.SaveChangesAsync();
            return group;
        }

        public async Task<List<Group>> GetUserGroups(int userId)
        {
            return await _dBContext.Groups.Where(s => s.CreatedBy == userId).ToListAsync();
        }

    }
}
