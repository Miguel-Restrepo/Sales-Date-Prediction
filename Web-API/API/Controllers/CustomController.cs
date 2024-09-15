namespace API.Controllers
{
    using Business.Dtos;
    using Business.Services;
    using Business.Services.Imp;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;


    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly ICustomService customerService;

        public CustomController(ICustomService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("GetSalesDatePrediction")]
        public async Task<IActionResult> GetSalesDatePrediction([FromQuery] string? customerName)
        {
            var customers = await this.customerService.GetSalesDatePrediction();
            if(customerName != null && customerName != "")
                customers = customers.Where(s => s.CompanyName.Contains(customerName)).ToList();
            return Ok(customers);
        }

        [HttpGet("GetOrdersByCustomerId/{id}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int id)
        {
            var orders = await this.customerService.GetOrdersByCustomerId(id);
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.customerService.CreateOrderAsync(createOrderDto);
            return Ok();
        }
    }
}
