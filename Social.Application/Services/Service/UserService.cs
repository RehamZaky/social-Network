using AutoMapper;
using Social.Application.DTO;
using Social.Application.Services.Interface;
using Social.Domain.Entities;
using Social.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Repository
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork,IMapper mapper,IUserRepository userRepository) {
         _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> GetAll()
        {
           var users= await _unitOfWork.GenericRepository<User>().GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetById(int id)
        {
          return _mapper.Map<UserDTO>( await _unitOfWork.GenericRepository<User>().GetById(id));
        }

        public async Task<UserDTO> Post(UserDTO userDTO)
        {
          var user =  _mapper.Map<User>(userDTO);
           var returnPost = await _unitOfWork.GenericRepository<User>().Post(user);
            return _mapper.Map<UserDTO>(returnPost);
        }

        public async Task<UserUpdateDTO> Put(UserUpdateDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var returnPost = await _unitOfWork.GenericRepository<User>().Put(user);
            return _mapper.Map<UserUpdateDTO>(returnPost);
        }
        public async Task Delete(int id)
        {
            await _unitOfWork.GenericRepository<User>().Delete(id);
        }

        public async Task<bool> DeactivateUser(bool isActive, int userId)
        {
           var response = await _userRepository.DeactivateUser(isActive, userId);
            if (!response)
                throw new KeyNotFoundException();

            return response;
        }
    }
}
