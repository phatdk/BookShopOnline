using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Order_BookController : ControllerBase
	{
		private IOrder_BookService _service;
        public Order_BookController(IOrder_BookService order_BookService)
        {
            _service = order_BookService;
        }

        // GET: api/<Order_BookController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idorder, Guid? idbook)
		{
			return Ok(await _service.GetAsync(idorder, idbook));
		}

		// GET api/<Order_BookController>/5
		[HttpGet("{idorder}/{idbook}")]
		public async Task<IActionResult> GetByIdAsync(Guid idoder, Guid idbook)
		{
			var obj = await _service.GetByIdAsync(idoder, idbook);
			if(obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<Order_BookController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] List<Order_BookVM> list)
		{
			if (list == null || list.Count == 0) return BadRequest();
			return Ok(await _service.AddAsync(list));
		}

		// PUT api/<Order_BookController>/5
		[HttpPut("update/{idorder}/{idbook}")]
		public async Task<IActionResult> UpdateAsync([FromBody] Order_BookVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<Order_BookController>/5
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteAsync(Guid idorder, Guid? idbook)
		{
			var obj = await _service.GetByIdAsync(idorder, idbook);
			if(obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(idorder, idbook));
		}
	}
}
