using Project_G2.DomainLayer.Model.RequestModel;
using Project_G2.DomainLayer.Model.ResponseModel;
using Project_G2API.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.BuissnessAccessLayer.Services.IServices
{
    public interface IEmployeeService
    {
        Task<ResponseModel> AddEmployee(AddEmployeeRequest addEmployeeRequest);
        Task<ResponseModel> GetEmployee();
        Task<ResponseModel> UpdateEmployee();
        Task<ResponseModel> DeleteEmployee();
        Task<ResponseModel> GetDepartmentCombo(DepartmentComboRequest departmentComboRequest);
        Task<ResponseModel> GetCountryCombo(CountryComboRequest countryComboRequest);
        Task<ResponseModel> GetStateCombo(StateComboRequest stateComboRequest);
        Task<ResponseModel> GetCityCombo(CityComboRequest cityComboRequest);

        Task<ResponseModel> CreateEmployee(CreateEmployeeRequest createEmployeeRequest);
        Task<ResponseModel> ReadEmployee();
        Task<ResponseModel> ReadEmployeeById(ReadEmployeeRequest readEmployeeRequest);
        Task<ResponseModel> DepartmentCombo();
        Task<ResponseModel> EditEmployee(EditEmployeeRequest editEmployeeRequest);
        Task<ResponseModel> getDepartmentById(getDepartmentByIdRequest getDepartmentById);
        Task<ResponseModel> RemoveEmployee(DeleteEmployeeRequest deleteEmployeeRequest);

    }
}
