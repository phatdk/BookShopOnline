using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PromotionController : ControllerBase
	{
		private IPromotionService _service;
        public PromotionController(IPromotionService promotionService)
        {
            _service = promotionService;
        }

        // GET: api/<PromotionController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idtype)
		{
			return Ok(await _service.GetAsync(idtype));
		}
		
        // GET: api/<PromotionController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(Guid? idtype)
		{
			return Ok(await _service.GetActiveAsync(idtype));
		}

		// GET api/<PromotionController>/5
		[HttpGet("get")]
		public async Task<IActionResult> GetByIdAsync(Guid? id, string? code)
		{
			var obj = await _service.GetByIdAsync(id,code);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<PromotionController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] PromotionVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<PromotionController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> updateAsync([FromBody] PromotionVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<PromotionController>/5
		[HttpDelete("update/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id, null);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
