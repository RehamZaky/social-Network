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
    public class FriendRepository : GenericRepository<Friend>, IFriendRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public FriendRepository(ApplicationDBContext applicationDB) : base(applicationDB)
        {
            _dBContext = applicationDB;
        }


        public async Task<List<Friend>> GetAllFriendsOfUser(int userId)
        {
           var friends =  await _dBContext.Friends.Include(s=> s.FriendUser).Where(f=> f.UserId == userId).ToListAsync();
           // var users =  await _dBContext.Friends.Include(s=> s.User).Where(f=> f.FriendId == userId).ToListAsync();
           // friends = friends.Concat(users).DistinctBy(i=> i.FriendId).ToList();
            
            return friends;
        }
        public async Task<bool> DeleteFriendship(int userId, int friendId)
        {
           var friendship = await _dBContext.Friends.FirstOrDefaultAsync(d => d.UserId == userId && d.FriendId == friendId);
            if(friendship != null)
            {
                _dBContext.Friends.Remove(friendship);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //public Task<Friend> SendFriendRequest(Friend friend)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
