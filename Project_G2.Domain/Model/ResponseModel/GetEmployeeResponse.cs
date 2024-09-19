using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_G2.DomainLayer.Model.ResponseModel
{
    public class GetEmployeeResponse
    {
        public int? EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public int? DepartmentID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? MobileNo { get; set; }
        public int? Gender { get; set; }
        public string? Address { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }
    }
}
