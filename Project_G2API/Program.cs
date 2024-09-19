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

app.UseHttpsRedirection();
app.MapControllers();


#region apis


app.MapPost("api/AddEmployee", async (IEmployeeService employeeService, AddEmployeeRequest addEmployeeRequest) =>
{
    return await employeeService.AddEmployee(addEmployeeRequest);
}).WithTags("Employee");

app.MapPost("api/GetEmployee", async (IEmployeeService employeeService) =>
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


app.Run();