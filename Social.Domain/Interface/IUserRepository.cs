using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<bool> DeactivateUser(bool isActive,int userId);

    }
}
