using Project_G2.DomainLayer.Model.RequestModel;
using Project_G2.DomainLayer.Model.ResponseModel;
using Project_G2API.Model.RequestModel;

namespace Project_G2.DataAccessLayer.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Task<ResponseModel> AddEmployee(AddEmployeeRequest addEmployeeRequest);
        Task<ResponseModel> GetEmployee();
        Task<ResponseModel> UpdateEmployee();
        Task<ResponseModel> DeleteEmployee();
        Task<ResponseModel> GetCountryCombo();
        Task<ResponseModel> GetStateCombo();
        Task<ResponseModel> GetCityCombo(CityComboRequest cityComboRequest);
    }
}
