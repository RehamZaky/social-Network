using AutoMapper;
using Social.Application.DTO;
using Social.Application.Services.Interface;
using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.Services.Service
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FriendService(IUnitOfWork unitOfWork, IMapper mapper) { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FriendDTO> CreateFriendRequest(FriendDTO friendDTO)
        {
            var friend = _mapper.Map<Friend>(friendDTO);
           var response = await _unitOfWork.GenericRepository<Friend>().Create(friend);
            return _mapper.Map<FriendDTO>(response);
        }


        public async Task<FriendDTO> UpdateFriendshipStatus(FriendDTO friendDTO)
        {
            var friend = _mapper.Map<Friend>(friendDTO);
            var response = await _unitOfWork.GenericRepository<Friend>().Update(friend);
            return _mapper.Map<FriendDTO>(response);
        }
        public async Task DeleteFriendReq(int userId,int friendId)
        {
            var response = await _unitOfWork.FriendRepository.DeleteFriendship( userId,friendId);
            if (!response)
                throw new KeyNotFoundException();

        }

        public async Task<List<FriendDetailsDTO>> GetAllFriendsOfUser(int userId)
        {
            var response = await _unitOfWork.FriendRepository.GetAllFriendsOfUser(userId);
            return _mapper.Map<List<FriendDetailsDTO>>(response);
        }

    }
}
