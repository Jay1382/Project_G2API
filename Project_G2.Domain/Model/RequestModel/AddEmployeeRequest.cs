﻿using System.ComponentModel.DataAnnotations;

namespace Project_G2API.Model.RequestModel
{
    public class AddEmployeeRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public int? DepartmentID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? MobileNo { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }
        public int? CityID { get; set; }

    }
}
