namespace API.Controllers
{
    using Business.Dtos;
    using Business.Services;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderDto> orderService;

        public OrderController(IService<OrderDto> orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await this.orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await this.orderService.GetById(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderDto orderDTO)
        {
            await this.orderService.Add(orderDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDto orderDTO)
        {
            await this.orderService.Update(orderDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await this.orderService.Delete(id);
            return Ok();
        }
    }
}
