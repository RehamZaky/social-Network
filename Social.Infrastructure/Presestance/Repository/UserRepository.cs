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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDBContext _dbContext; 
        public UserRepository(ApplicationDBContext applicationDB): base(applicationDB) {
         _dbContext = applicationDB;
        }

        public async Task<bool> DeactivateUser(bool isActive, int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if(user == null)
            {
                return  false;
            }
            user.IsActive = isActive;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
