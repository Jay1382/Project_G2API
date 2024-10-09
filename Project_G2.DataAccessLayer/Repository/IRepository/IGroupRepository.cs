using Project_G2.DomainLayer.Model.RequestModel;
using Project_G2.DomainLayer.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.DataAccessLayer.Repository.IRepository
{
    public interface IGroupRepository
    {
        Task<ResponseModel> AddGroup(AddGroupRequest addGroupRequest);
        Task<ResponseModel> GetGroup();
        Task<ResponseModel> GetGroupById(GetGroupRequest getGroupRequest);
        Task<ResponseModel> UpdateGroup(UpdateGroupRequest updateGroupRequest);
        Task<ResponseModel> DeleteGroup(DeleteGroupRequest deleteGroupRequest);
        Task<ResponseModel> GetGroupCombo();
    }
}
