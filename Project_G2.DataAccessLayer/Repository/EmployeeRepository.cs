using Dapper;
using FileManager.DataAccessLayer.DataContext;
using Microsoft.Extensions.Configuration;
using Project_G2.DataAccessLayer.Repository.IRepository;
using Project_G2.DomainLayer.Model.DTO;
using Project_G2.DomainLayer.Model.RequestModel;
using Project_G2.DomainLayer.Model.ResponseModel;
using Project_G2API.Model.RequestModel;
using System.Data;

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

        public async Task<ResponseModel> GetCountryCombo(CountryComboRequest countryComboRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@label", countryComboRequest.label);
                    parameter.Add("@page_size", countryComboRequest.PageSize);
                    parameter.Add("@current_page", countryComboRequest.CurrentPage);
                    var result = await connection.QueryMultipleAsync("country_combo_get", parameter, commandType: CommandType.StoredProcedure);
                    var paginationResponse = result.Read<PaginationResponse>();
                    var countryResponse = result.Read<CountryComboResponse>();
                    if (countryResponse.FirstOrDefault() != null)
                    {
                        CountryComboDTO countryComboDTO = new CountryComboDTO();
                        countryComboDTO.paginationResponse = paginationResponse.FirstOrDefault();
                        countryComboDTO.countryComboResponse = countryResponse.ToList();

                        responseModel.StatusCode = 200;
                        responseModel.Message = "data get successfully!!";
                        responseModel.Data = countryComboDTO;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during GetCountryCombo: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> GetStateCombo(StateComboRequest stateComboRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@CountryID", stateComboRequest.CountryID);
                    parameter.Add("@page_size", stateComboRequest.PageSize);
                    parameter.Add("@current_page", stateComboRequest.CurrentPage);
                    var result = await connection.QueryMultipleAsync("state_combo_get", parameter, commandType: CommandType.StoredProcedure);
                    var paginationResponse = result.Read<PaginationResponse>();
                    var stateResponse = result.Read<StateComboResponse>();
                    if (stateResponse.FirstOrDefault() != null)
                    {
                        StateComboDTO stateComboDTO = new StateComboDTO();
                        stateComboDTO.paginationResponse = paginationResponse.FirstOrDefault();
                        stateComboDTO.stateComboResponse = stateResponse.ToList();

                        responseModel.StatusCode = 200;
                        responseModel.Message = "data get successfully!!";
                        responseModel.Data = stateComboDTO;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during GetStateCombo: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> GetDepartmentCombo(DepartmentComboRequest departmentComboRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@label", departmentComboRequest.label);
                    parameter.Add("@page_size", departmentComboRequest.PageSize);
                    parameter.Add("@current_page", departmentComboRequest.CurrentPage);
                    var result = await connection.QueryMultipleAsync("department_combo_get", parameter, commandType: CommandType.StoredProcedure);
                    var paginationResponse = result.Read<PaginationResponse>();
                    var departmentResponse = result.Read<DepartmentComboResponse>();
                    if (departmentResponse.FirstOrDefault() != null)
                    {
                        DepartmentComboDTO departmentComboDTO = new DepartmentComboDTO();
                        departmentComboDTO.paginationResponse = paginationResponse.FirstOrDefault();
                        departmentComboDTO.departmentComboResponse = departmentResponse.ToList();

                        responseModel.StatusCode = 200;
                        responseModel.Message = "data get successfully!!";
                        responseModel.Data = departmentComboDTO;
                    }
                }
                catch (Exception ex)
                {
                    responseModel.StatusCode = 500;
                    responseModel.Message = $"Error occurred during GetDepartmentCombo: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> CreateEmployee(CreateEmployeeRequest createEmployeeRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@FirstName", createEmployeeRequest.FirstName);
                    parameter.Add("@LastName", createEmployeeRequest.LastName);
                    parameter.Add("@DepartmentId", createEmployeeRequest.DepartmentId);
                    var result = await connection.QueryAsync<int>("employee_create", parameter, commandType: CommandType.StoredProcedure);
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
                    responseModel.Message = $"Error occurred during CreateEmployee: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> ReadEmployee()
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    var result = await connection.QueryAsync<ReadEmployeeResponse>("employee_read", commandType: CommandType.StoredProcedure);
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

        public async Task<ResponseModel> ReadEmployeeById(ReadEmployeeRequest readEmployeeRequest)
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Id", readEmployeeRequest.Id);
                    var result = await connection.QueryAsync<ReadEmployeeResponse>("employee_read_id", parameter, commandType: CommandType.StoredProcedure);
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
                    responseModel.Message = $"Error occurred during ReadEmployeeById: {ex.Message}";
                }
                return responseModel;
            }
        }

        public async Task<ResponseModel> DepartmentCombo()
        {
            using (var connection = _context.CreateConnection())
            {
                ResponseModel responseModel = new ResponseModel();
                try
                {
                    var result = await connection.QueryAsync<DepartmentComboRes>("department_combo", commandType: CommandType.StoredProcedure);
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
                    responseModel.Message = $"Error occurred during ReadEmployeeById: {ex.Message}";
                }
                return responseModel;
            }
        }

        public Task<ResponseModel> EditEmployee(EditEmployeeRequest editEmployeeRequest)
        {
            throw new NotImplementedException();
        }
    }
}
