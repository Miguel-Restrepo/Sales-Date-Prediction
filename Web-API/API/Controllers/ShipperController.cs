namespace API.Controllers
{
    using Business.Dtos;
    using Business.Services;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IService<ShipperDto> shipperService;

        public ShipperController(IService<ShipperDto> shipperService)
        {
            this.shipperService = shipperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShippers()
        {
            var shippers = await this.shipperService.GetAll();
            return Ok(shippers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipperById(int id)
        {
            var shipper = await this.shipperService.GetById(id);
            if (shipper == null)
                return NotFound();
            return Ok(shipper);
        }

        [HttpPost]
        public async Task<IActionResult> AddShipper([FromBody] ShipperDto shipperDTO)
        {
            await this.shipperService.Add(shipperDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShipper([FromBody] ShipperDto shipperDTO)
        {
            await this.shipperService.Update(shipperDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipper(int id)
        {
            await this.shipperService.Delete(id);
            return Ok();
        }
    }
}
