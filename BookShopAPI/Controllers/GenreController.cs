using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : ControllerBase
	{
		private IGenreService _service;
        public GenreController(IGenreService genreService)
        {
            _service = genreService;
        }

        // GET: api/<GenreController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(string? name)
		{
			return Ok(await _service.GetAsync(name));
		}
		
        // GET: api/<GenreController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(string? name)
		{
			return Ok(await _service.GetActiveAsync(name));
		}

		// GET api/<GenreController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if(obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<GenreController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] GenreVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<GenreController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] GenreVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<GenreController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if(obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
