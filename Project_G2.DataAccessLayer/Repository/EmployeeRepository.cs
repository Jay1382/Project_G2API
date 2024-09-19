using Dapper;
using FileManager.DataAccessLayer.DataContext;
using Microsoft.Extensions.Configuration;
using Project_G2.DataAccessLayer.Repository.IRepository;
using Project_G2.DomainLayer.Model.DTO;
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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperDBContext _context;
        private readonly IConfiguration _configuration;
        public EmployeeRepository(DapperDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ResponseModel> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@FirstName", addEmployeeRequest.FirstName);
                    parameter.Add("@LastName", addEmployeeRequest.LastName);
                    parameter.Add("@Email", addEmployeeRequest.Email);
                    parameter.Add("@Designation", addEmployeeRequest.Designation);
                    parameter.Add("@DepartmentID", addEmployeeRequest.DepartmentID);
                    parameter.Add("@DateOfBirth", addEmployeeRequest.DateOfBirth);
                    parameter.Add("@MobileNo", addEmployeeRequest.MobileNo);
                    parameter.Add("@Gender", addEmployeeRequest.Gender);
                    parameter.Add("@Address", addEmployeeRequest.Address);
                    parameter.Add("@CountryID", addEmployeeRequest.CountryID);
                    parameter.Add("@StateID", addEmployeeRequest.StateID);
                    parameter.Add("@CityID", addEmployeeRequest.CityID);
                    var result = await connection.QueryAsync<int>("employee_insert", parameter, commandType: CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        responseModel.StatusCode = 200;
                        responseModel.Message = "Employee added successfully!!";
                        responseModel.Data = result;
                    }
                }                
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during AddEmployee: {ex.Message}";
                }
                return responseModel;
            }
        }
 
        public async Task<ResponseModel> GetEmployee()
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();;
                    var result = await connection.QueryAsync<GetEmployeeResponse>("employee_get", parameter, commandType: CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {
                        responseModel.StatusCode = 200;
                        responseModel.Message = "Get Employee successfully!!";
                        responseModel.Data = result;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during GetEmployee: {ex.Message}";
                }
                return responseModel;
            }
        }

        public Task<ResponseModel> UpdateEmployee()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetCityCombo(CityComboRequest cityComboRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@StateID", cityComboRequest.StateID);
                    parameter.Add("@page_size", cityComboRequest.PageSize);
                    parameter.Add("@current_page", cityComboRequest.CurrentPage);                    
                    var result = await connection.QueryMultipleAsync("city_combo_get", parameter, commandType: CommandType.StoredProcedure);                    
                    var paginationResponse = result.Read<PaginationResponse>();
                    var cityResponse = result.Read<CityComboResponse>();                    
                    if (cityResponse.FirstOrDefault() != null)
                    {
                        CityComboDTO cityComboDTO = new CityComboDTO();
                        cityComboDTO.cityComboResponse = cityResponse.ToList();
                        cityComboDTO.paginationResponse = paginationResponse.FirstOrDefault();

                        responseModel.StatusCode = 200;
                        responseModel.Message = "data get successfully!!";
                        responseModel.Data = cityComboDTO;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during GetCityCombo: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> GetCountryCombo()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetStateCombo()
        {
            throw new NotImplementedException();
        }
    }
}
