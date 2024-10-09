using Dapper;
using FileManager.DataAccessLayer.DataContext;
using Microsoft.Extensions.Configuration;
using Project_G2.DataAccessLayer.Repository.IRepository;
using Project_G2.DomainLayer.Model.RequestModel;
using Project_G2.DomainLayer.Model.ResponseModel;
using Project_G2API.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.DataAccessLayer.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DapperDBContext _context;
        private readonly IConfiguration _configuration;
        public GroupRepository(DapperDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ResponseModel> AddGroup(AddGroupRequest addGroupRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Status", addGroupRequest.Status);
                    parameter.Add("@GroupName", addGroupRequest.GroupName);
                    var result = await connection.QueryAsync<int>("group_insert", parameter, commandType: CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        responseModel.StatusCode = 200;
                        responseModel.Message = "Group added successfully!!";
                        responseModel.Data = result;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during AddGroup: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> GetGroup()
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    var result = await connection.QueryAsync<GetGroupResponse>("group_get", commandType: CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        responseModel.StatusCode = 200;
                        responseModel.Message = "Get Group successfully!!";
                        responseModel.Data = result;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during GetGroup: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> GetGroupById(GetGroupRequest getGroupRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@id", getGroupRequest.Id);
                    var result = await connection.QueryAsync<GetGroupResponse>("group_get_id", parameter, commandType: CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        responseModel.StatusCode = 200;
                        responseModel.Message = "Group get successfully!!";
                        responseModel.Data = result;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during GetGroupById: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> UpdateGroup(UpdateGroupRequest updateGroupRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Id", updateGroupRequest.Id);
                    parameter.Add("@GroupName", updateGroupRequest.GroupName);
                    parameter.Add("@Status", updateGroupRequest.Status);
                    var result = await connection.QueryAsync<int>("group_update", parameter, commandType: CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        responseModel.StatusCode = 200;
                        responseModel.Message = "Group updated successfully!!";
                        responseModel.Data = result;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during UpdateGroup: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> DeleteGroup(DeleteGroupRequest deleteGroupRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Id", deleteGroupRequest.Id);
                    var result = await connection.QueryAsync<int>("group_delete", parameter, commandType: CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        responseModel.StatusCode = 200;
                        responseModel.Message = "Group deleted successfully!!";
                        responseModel.Data = result;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during DeleteGroup: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> GetGroupCombo()
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    var result = await connection.QueryAsync<GetGroupComboResponse>("group_combo_get", commandType: CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        responseModel.StatusCode = 200;
                        responseModel.Message = "GetGroupCombo successfully!!";
                        responseModel.Data = result;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during GetGroupCombo: {ex.Message}";
                }
                return responseModel;
            }
        }
    }
}
