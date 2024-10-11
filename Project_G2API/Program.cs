using Microsoft.Net.Http.Headers;
using Project_G2.BuissnessAccessLayer.Services.IServices;
using Project_G2.DomainLayer.Model.RequestModel;
using Project_G2API.Helper;
using Project_G2API.Model.RequestModel;

var builder = WebApplication.CreateBuilder(args);
DependencyInjectionConfig.ConfigureServices(builder.Services);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
    });
}
app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithHeaders(HeaderNames.ContentType);
});
app.UseHttpsRedirection();
app.MapControllers();


#region apis 


app.MapPost("api/AddEmployee", async (IEmployeeService employeeService, AddEmployeeRequest addEmployeeRequest) =>
{
    return await employeeService.AddEmployee(addEmployeeRequest);
}).WithTags("Employee");

app.MapGet("api/GetEmployee", async (IEmployeeService employeeService) =>
{
    return await employeeService.GetEmployee();
}).WithTags("Employee");

app.MapPost("api/UpdateEmployee", async (IEmployeeService employeeService) =>
{
    return await employeeService.UpdateEmployee();
}).WithTags("Employee");

app.MapPost("api/DeleteEmployee", async (IEmployeeService employeeService) =>
{
    return await employeeService.DeleteEmployee();
}).WithTags("Employee");

app.MapPost("api/GetDepartmentCombo", async (IEmployeeService employeeService, DepartmentComboRequest departmentComboRequest) =>
{
    return await employeeService.GetDepartmentCombo(departmentComboRequest);
}).WithTags("Employee");

app.MapPost("api/GetCountryCombo", async (IEmployeeService employeeService, CountryComboRequest countryComboRequest) =>
{
    return await employeeService.GetCountryCombo(countryComboRequest);
}).WithTags("Employee");

app.MapPost("api/GetStateCombo", async (IEmployeeService employeeService, StateComboRequest stateComboRequest) =>
{
    return await employeeService.GetStateCombo(stateComboRequest);
}).WithTags("Employee");

app.MapPost("api/GetCityCombo", async (IEmployeeService employeeService, CityComboRequest cityComboRequest) =>
{
    return await employeeService.GetCityCombo(cityComboRequest);
}).WithTags("Employee");


#endregion


#region group apis 

app.MapPost("api/AddGroup", async (IGroupService groupService, AddGroupRequest addGroupRequest) =>
{
    return await groupService.AddGroup(addGroupRequest);
}).WithTags("Group");

app.MapGet("api/GetGroup", async (IGroupService groupService) =>
{
    return await groupService.GetGroup();
}).WithTags("Group");

app.MapPost("api/GetGroupById", async (IGroupService groupService, GetGroupRequest getGroupRequest) =>
{
    return await groupService.GetGroupById(getGroupRequest);
}).WithTags("Group");

app.MapPut("api/UpdateGroup", async (IGroupService groupService, UpdateGroupRequest updateGroupRequest) =>
{
    return await groupService.UpdateGroup(updateGroupRequest);
}).WithTags("Group");

app.MapPost("api/DeleteGroup", async (IGroupService groupService, DeleteGroupRequest deleteGroupRequest) =>
{
    return await groupService.DeleteGroup(deleteGroupRequest);
}).WithTags("Group");

app.MapPost("api/GetGroupCombo", async (IGroupService groupService) =>
{
    return await groupService.GetGroupCombo();
}).WithTags("Group");



#endregion






app.MapPost("api/CreateEmployee", async (IEmployeeService employeeService, CreateEmployeeRequest createEmployeeRequest) =>
{
    return await employeeService.CreateEmployee(createEmployeeRequest);
}).WithTags("Employee");

app.MapGet("api/ReadEmployee", async (IEmployeeService employeeService) =>
{
    return await employeeService.ReadEmployee();
}).WithTags("Employee");

app.MapPost("api/ReadEmployeeById", async (IEmployeeService employeeService, ReadEmployeeRequest readEmployeeRequest) =>
{
    return await employeeService.ReadEmployeeById(readEmployeeRequest);
}).WithTags("Employee");

app.MapGet("api/DepartmentCombo", async (IEmployeeService employeeService) =>
{
    return await employeeService.DepartmentCombo();
}).WithTags("Employee");

app.MapPost("api/getDepartmentById", async (IEmployeeService employeeService, getDepartmentByIdRequest getDepartmentById) =>
{
    return await employeeService.getDepartmentById(getDepartmentById);
}).WithTags("Employee");

app.MapPost("api/EditEmployee", async (IEmployeeService employeeService, EditEmployeeRequest editEmployeeRequest) =>
{
    return await employeeService.EditEmployee(editEmployeeRequest);
}).WithTags("Employee");

app.MapPost("api/RemoveEmployee", async (IEmployeeService employeeService, DeleteEmployeeRequest deleteEmployeeRequest) =>
{
    return await employeeService.RemoveEmployee(deleteEmployeeRequest);
}).WithTags("Employee");


app.Run();