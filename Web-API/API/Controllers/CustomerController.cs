namespace API.Controllers
{
    using Business.Dtos;
    using Business.Services;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IService<CustomerDto> customerService;

        public CustomerController(IService<CustomerDto> customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await this.customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await this.customerService.GetById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDto customerDTO)
        {
            await this.customerService.Add(customerDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDTO)
        {
            await this.customerService.Update(customerDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await this.customerService.Delete(id);
            return Ok();
        }
    }
}
