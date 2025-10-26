using Social.Application.DTO;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Interface
{
    public interface IFriendService 
    {
        public Task<List<FriendDetailsDTO>> GetAllFriendsOfUser(int userId);
        public Task<FriendDTO> CreateFriendRequest(FriendDTO t);
        public Task<FriendDTO> UpdateFriendshipStatus(FriendDTO t);
        public Task DeleteFriendReq(int userId, int friendId);
    }
}
