using Project_G2.BuissnessAccessLayer.Services.IServices;
using Project_G2.DataAccessLayer.Repository.IRepository;
using Project_G2.DomainLayer.Model.RequestModel;
using Project_G2.DomainLayer.Model.ResponseModel;
using Project_G2API.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.BuissnessAccessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ResponseModel> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            return await _employeeRepository.AddEmployee(addEmployeeRequest);
        }

        public async Task<ResponseModel> GetEmployee()
        {
            return await _employeeRepository.GetEmployee();
        }

        public async Task<ResponseModel> UpdateEmployee()
        {
            return await _employeeRepository.UpdateEmployee();
        }

        public async Task<ResponseModel> DeleteEmployee()
        {
            return await _employeeRepository.DeleteEmployee();
        }

        public async Task<ResponseModel> GetCityCombo(CityComboRequest cityComboRequest)
        {
            return await _employeeRepository.GetCityCombo(cityComboRequest);
        }

        public async Task<ResponseModel> GetCountryCombo(CountryComboRequest countryComboRequest)
        {
            return await _employeeRepository.GetCountryCombo(countryComboRequest);
        }

        public async Task<ResponseModel> GetStateCombo(StateComboRequest stateComboRequest)
        {
            return await _employeeRepository.GetStateCombo(stateComboRequest);
        }

        public async Task<ResponseModel> GetDepartmentCombo(DepartmentComboRequest departmentComboRequest)
        {
            return await _employeeRepository.GetDepartmentCombo(departmentComboRequest);
        }

        public async Task<ResponseModel> CreateEmployee(CreateEmployeeRequest createEmployeeRequest)
        {
            return await _employeeRepository.CreateEmployee(createEmployeeRequest);
        }

        public async Task<ResponseModel> ReadEmployee()
        {
            return await _employeeRepository.ReadEmployee();
        }

        public async Task<ResponseModel> ReadEmployeeById(ReadEmployeeRequest readEmployeeRequest)
        {
            return await _employeeRepository.ReadEmployeeById(readEmployeeRequest);
        }

        public async Task<ResponseModel> DepartmentCombo()
        {
            return await _employeeRepository.DepartmentCombo();
        }

        public async Task<ResponseModel> EditEmployee(EditEmployeeRequest editEmployeeRequest)
        {
            return await _employeeRepository.EditEmployee(editEmployeeRequest);
        }
    }
}
