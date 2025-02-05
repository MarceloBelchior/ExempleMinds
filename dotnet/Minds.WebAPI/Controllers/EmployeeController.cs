using Microsoft.AspNetCore.Mvc;

namespace Minds.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly Minds.Interface.Domain.IEmployeeBS _employeeBS;
        private readonly Minds.Interface.Domain.IDepartamentBS _departamentBS;
        public EmployeeController(Minds.Interface.Domain.IEmployeeBS employeeBS, Interface.Domain.IDepartamentBS departamentBS)
        {
            _employeeBS = employeeBS;
            _departamentBS = departamentBS;
        }
        [HttpGet]
        [Route("GetEmployeeById")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("GetEmployeeById")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "Success", typeof(Minds.Interface.Model.Employee))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(400, "Bad Request", typeof(Minds.Interface.Model.Employee))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(500, "Internal Server Error", typeof(Minds.Interface.Model.Employee))]

        public async Task<IActionResult> GetEmployeeById(Interface.Model.Employee employee)
        {
            var employees = _employeeBS.GetEmployees(employee);
            return Ok(employees);
        }
        [HttpPost]
        [Route("CreateOrUpdateEmployee")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("CreateOrUpdateEmployee")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "Success", typeof(Minds.Interface.Model.Employee))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(400, "Bad Request", typeof(Minds.Interface.Model.Employee))]

        public async Task<IActionResult> CreateOrUpdateEmployee(Interface.Model.Employee employee)
        {
            var employees = _employeeBS.CreateOrUpdateEmployee(employee);
            return Ok(employees);
        }
        [HttpGet]
        [Route("GetAll")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("GetAll")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(200, "Success", typeof(List<Minds.Interface.Model.Employee>))]
        public async Task<IActionResult> GetAll()
        {
            var employees = _employeeBS.GetAll();
            return Ok(employees);
        }
       
    }
}
