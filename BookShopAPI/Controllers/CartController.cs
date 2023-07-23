using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private ICartService _service;
        public CartController(ICartService cartService)
        {
			_service = cartService;
        }

        // GET: api/<CartController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idcustomer, Guid? idbook)
		{
			return Ok(await _service.GetAsync(idcustomer, idbook));
		}

		// GET api/<CartController>/5
		[HttpGet("{idcustomer}/{idbook}")]
		public async Task<IActionResult> GetByIdAsync(Guid idcustomer, Guid idbook)
		{
			var obj = await _service.GetByIdAsync(idcustomer, idbook);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<CartController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] CartVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<CartController>/5
		[HttpPut("update/{idcustomer}/{idbook}")]
		public async Task<IActionResult> UpdateAsync([FromBody] CartVM request)
		{
			if (request == null) return NotFound();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<CartController>/5
		[HttpDelete("delete/{idcustomer}/{idbook}")]
		public async Task<IActionResult> DeleteAsync(Guid idcustomer, Guid idbook)
		{
			var obj = await _service.GetByIdAsync(idcustomer, idbook);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(idcustomer, idbook));
		}
	}
}
