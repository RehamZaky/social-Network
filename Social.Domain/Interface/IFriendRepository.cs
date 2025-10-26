using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Interface
{
    public interface IFriendRepository : IGenericRepository<Friend>
    {
        public Task<List<Friend>> GetAllFriendsOfUser(int userId);

        public Task<bool> DeleteFriendship(int userId,int friendId);
    }
}
