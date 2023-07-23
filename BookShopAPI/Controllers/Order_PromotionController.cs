using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Order_PromotionController : ControllerBase
	{
		private IOrder_PromotionService _service;
        public Order_PromotionController(IOrder_PromotionService order_PromotionService)
        {
            _service = order_PromotionService;
        }

        // GET: api/<Order_PromotionController>
        [HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idorder, Guid? idpromotion)
		{
			return Ok(await _service.GetAsync(idorder, idpromotion));
		}

		// GET api/<Order_PromotionController>/5
		[HttpGet("{idorder}/{idpromotion}")]
		public async Task<IActionResult> GetByIdAsync(Guid idorder, Guid idpromotion)
		{
			var obj = await _service.GetByIdAsync(idorder, idpromotion);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<Order_PromotionController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] List<Order_PromotionVM> request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<Order_PromotionController>/5
		[HttpPut("update/{idorder}/{idpromotion}")]
		public async Task<IActionResult> UpdateAsync([FromBody] Order_PromotionVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<Order_PromotionController>/5
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteAsync(Guid idorder, Guid idpromotion)
		{
			var obj = await _service.GetByIdAsync(idorder, idpromotion);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(idorder, idpromotion));
		}
	}
}
