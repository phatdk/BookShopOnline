using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Promotion_TypeController : ControllerBase
	{
		private IPromotion_TypeService _service;
        public Promotion_TypeController(IPromotion_TypeService promotion_TypeService)
        {
            _service = promotion_TypeService;
        }

        // GET: api/<Promotion_TypeController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync()
		{
			return Ok(await _service.GetAsync());
		}
		
        // GET: api/<Promotion_TypeController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync()
		{
			return Ok(await _service.GetActiveAsync());
		}

		// GET api/<Promotion_TypeController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			return Ok(await _service.GetByIdAsync(id));
		}

		// POST api/<Promotion_TypeController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] Promotion_TypeVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<Promotion_TypeController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] Promotion_TypeVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<Promotion_TypeController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if(obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
