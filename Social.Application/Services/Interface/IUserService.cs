using Social.Application.DTO;
using Social.Domain.Entities;

namespace Social.Application.Services.Interface
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAll();
        public Task<UserDTO> Post(UserDTO t);
        public Task<UserDTO> GetById(int id);

        public Task<UserUpdateDTO> Put(UserUpdateDTO t);
        public Task Delete(int id);

        public Task<bool> DeactivateUser(bool isActive, int userId);
    }
}
