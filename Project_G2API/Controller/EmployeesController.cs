using Microsoft.AspNetCore.Mvc;
using Project_G2.BuissnessAccessLayer.Services.IServices;

namespace Project_G2API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            var response = await _employeeService.GetEmployee();
            return Ok(response);
        }
    }
}
