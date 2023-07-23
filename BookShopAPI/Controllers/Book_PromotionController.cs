using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Book_PromotionController : ControllerBase
	{
		private IBook_PromotionService _service;
        public Book_PromotionController(IBook_PromotionService book_PromotionService)
        {
            _service = book_PromotionService;
        }
        // GET: api/<Book_PromotionController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idbook, Guid? idpromotion)
		{
			return Ok(await _service.GetAsync(idbook, idpromotion));
		}

        // GET: api/<Book_PromotionController>
        [HttpGet("active")]
		public async Task<IActionResult> GetActiceAsync(Guid? idbook, Guid? idpromotion)
		{
			return Ok(await _service.GetActiveAsync(idbook, idpromotion));
		}

		// GET api/<Book_PromotionController>/5
		[HttpGet("id")]
		public async Task<IActionResult> GetByIdAsync(Guid? idbook, Guid? idpromotion)
		{
			return Ok(await _service.GetByIdAsync(idbook, idpromotion));
		}

		// POST api/<Book_PromotionController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] List<Book_PromotionVM> request)
		{
			if (request == null)
			{
				return BadRequest();
			}
			var result = await _service.AddAsync(request);
			return Ok(result);
		}

		// PUT api/<Book_PromotionController>/5
		[HttpPut("update/{idbook}/{idpromorion}")]
		public async Task<IActionResult> UpdateAsync([FromBody] Book_PromotionVM request)
		{
			if(request == null)
			{
				return BadRequest();
			}
			var result = await _service.UpdateAsync(request); return Ok(result);
		}

		// DELETE api/<Book_PromotionController>/5
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteAsync(Guid idbook, Guid idpromotion)
		{
			var obj = await _service.GetByIdAsync(idbook, idpromotion);
			if (obj == null) return NotFound();
			var result = await _service.DeleteAsync(idbook, idpromotion);
			return Ok(result);
			
		}
	}
}
