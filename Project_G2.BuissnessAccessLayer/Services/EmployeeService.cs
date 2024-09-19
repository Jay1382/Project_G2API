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

        public Task<ResponseModel> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            return _employeeRepository.AddEmployee(addEmployeeRequest);
        }

        public Task<ResponseModel> GetEmployee()
        {
            return _employeeRepository.GetEmployee();
        }

        public Task<ResponseModel> UpdateEmployee()
        {
            return _employeeRepository.UpdateEmployee();
        }

        public Task<ResponseModel> DeleteEmployee()
        {
            return _employeeRepository.DeleteEmployee();
        }

        public async Task<ResponseModel> GetCityCombo(CityComboRequest cityComboRequest)
        {
            return await _employeeRepository.GetCityCombo(cityComboRequest);
        }

        public async Task<ResponseModel> GetCountryCombo()
        {
            return await _employeeRepository.GetCountryCombo();
        }

        public Task<ResponseModel> GetStateCombo()
        {
            return _employeeRepository.GetStateCombo();
        }
    }
}
