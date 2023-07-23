using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PublisherController : ControllerBase
	{
		private IPublisherService _service;
        public PublisherController(IPublisherService publisherService)
        {
            _service = publisherService;
        }

		// GET: api/<PublisherController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync(string? name)
		{
			return Ok(await _service.GetAsync(name));
		}

		// GET: api/<PublisherController>
		[HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(string? name)
		{
			return Ok(await _service.GetActiveAsync(name));
		}

		// GET api/<PublisherController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<PublisherController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] PublisherVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<PublisherController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> updateAsync([FromBody] PublisherVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<PublisherController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
