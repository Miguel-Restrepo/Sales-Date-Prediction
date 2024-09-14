namespace API.Controllers
{
    using Business.Dtos;
    using Business.Services;
    using Business.Services.Imp;
    using Microsoft.AspNetCore.Mvc;


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
        public async Task<IActionResult> GetSalesDatePrediction()
        {
            var customers = await this.customerService.GetSalesDatePrediction();
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
