using Project_G2.BuissnessAccessLayer.Services.IServices;
using Project_G2.DataAccessLayer.Repository;
using Project_G2.DataAccessLayer.Repository.IRepository;
using Project_G2.DomainLayer.Model.RequestModel;
using Project_G2.DomainLayer.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.BuissnessAccessLayer.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<ResponseModel> AddGroup(AddGroupRequest addGroupRequest)
        {
            return await _groupRepository.AddGroup(addGroupRequest);
        }

        public async Task<ResponseModel> GetGroup()
        {
            return await _groupRepository.GetGroup();
        }

        public async Task<ResponseModel> GetGroupById(GetGroupRequest getGroupRequest)
        {
            return await _groupRepository.GetGroupById(getGroupRequest);
        }

        public async Task<ResponseModel> UpdateGroup(UpdateGroupRequest updateGroupRequest)
        {
            return await _groupRepository.UpdateGroup(updateGroupRequest);
        }

        public async Task<ResponseModel> DeleteGroup(DeleteGroupRequest deleteGroupRequest)
        {
            return await _groupRepository.DeleteGroup(deleteGroupRequest);
        }

        public async Task<ResponseModel> GetGroupCombo()
        {
            return await _groupRepository.GetGroupCombo();
        }
    }
}
