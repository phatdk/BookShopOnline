using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Delivery_AddressController : ControllerBase
	{
		private IDelivery_AddressService _service;
        public Delivery_AddressController(IDelivery_AddressService delivery_AddressService)
        {
            _service = delivery_AddressService;
        }

        // GET: api/<Delivery_AddressController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idcustomer)
		{
			return Ok(await _service.GetAsync(idcustomer));
		}
		
        // GET: api/<Delivery_AddressController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(Guid? idcustomer)
		{
			return Ok(await _service.GetActiveAsync(idcustomer));
		}

		// GET api/<Delivery_AddressController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<Delivery_AddressController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] Delivery_AddressVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<Delivery_AddressController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] Delivery_AddressVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<Delivery_AddressController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
