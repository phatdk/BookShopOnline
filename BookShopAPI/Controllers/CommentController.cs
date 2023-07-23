using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private ICommentService _service;
        public CommentController(ICommentService commentService)
        {
            _service = commentService;
        }

        // GET: api/<CommentController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idbook, Guid? idcustomer, Guid? idparents)
		{
			return Ok(await _service.GetAsync(idbook, idcustomer, idparents));
		}

		// GET api/<CommentController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<CommentController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] CommentVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<CommentController>/5
		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] CommentVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<CommentController>/5
		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var obj = await _service.GetByIdAsync(id);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(id));
		}
	}
}
