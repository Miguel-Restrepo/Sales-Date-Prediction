namespace API.Controllers
{
    using Business.Dtos;
    using Business.Services;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<EmployeeDto> employeeService;

        public EmployeeController(IService<EmployeeDto> employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await this.employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await this.employeeService.GetById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDTO)
        {
            await this.employeeService.Add(employeeDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto employeeDTO)
        {
            await this.employeeService.Update(employeeDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await this.employeeService.Delete(id);
            return Ok();
        }
    }
}
