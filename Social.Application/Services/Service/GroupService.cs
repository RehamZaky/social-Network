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

namespace Social.Application.Services.Service
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GroupService(IUnitOfWork unitOfWork,IMapper mapper,IGroupRepository groupRepository) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Group>> GetAll()
        {
           return await _unitOfWork.GenericRepository<Group>().GetAll();
        }

        public async Task<GroupDTO> GetById(int id)
        {
            var group = await _unitOfWork.GenericRepository<Group>().GetById(id);
            return _mapper.Map<GroupDTO>(group);
        }

        public async Task<GroupDTO> Post(GroupDTO t)
        {
            var group = _mapper.Map<Group>(t);
            var groupResponse = await _unitOfWork.GenericRepository<Group>().Post(group);
            return _mapper.Map<GroupDTO>(groupResponse);
        }

        public async Task<GroupDTO> Put(GroupEditDTO t)
        {
            var group = _mapper.Map<Group>(t);
            var groupResponse = await _unitOfWork.GenericRepository<Group>().Put(group);
            return _mapper.Map<GroupDTO>(groupResponse);
        }
        public async Task Delete(int id)
        {
            await _unitOfWork.GenericRepository<Group>().Delete(id);
        }

        public async Task<List<Group>> GetUserGroups(int userId)
        {
            return await _unitOfWork.GroupRepository.GetUserGroups(userId);
        }

        public async Task<Group> DeactivateGroup(int groupId, bool isActive)
        {
            return await _unitOfWork.GroupRepository.DeactivateGroup(groupId, isActive);
        }
    }
}
