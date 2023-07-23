using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookShopAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Customer_PromotionController : ControllerBase
	{
		private ICustomer_PromotionService _service;
        public Customer_PromotionController(ICustomer_PromotionService customer_PromotionService)
        {
            _service = customer_PromotionService;
        }

		// GET: api/<Customer_PromotionController>
		[HttpGet("all")]
		public async Task<IActionResult> GetAsync(Guid? idcustomer, Guid? idpromotion)
		{
			return Ok(await _service.GetAsync(idcustomer, idpromotion));
		}
		
		// GET: api/<Customer_PromotionController>
		[HttpGet("active")]
		public async Task<IActionResult> GetActiveAsync(Guid? idcustomer, Guid? idpromotion)
		{
			return Ok(await _service.GetActiveAsync(idcustomer, idpromotion));
		}

		// GET api/<Customer_PromotionController>/5
		[HttpGet("{idcustomer}/{idpromotion}")]
		public async Task<IActionResult> GetByIdAsync(Guid idcustomer, Guid idpromotion)
		{
			var obj = await _service.GetByIdAsync(idcustomer, idpromotion);
			if (obj == null) return NotFound();
			return Ok(obj);
		}

		// POST api/<Customer_PromotionController>
		[HttpPost("add")]
		public async Task<IActionResult> AddAsync([FromBody] List<Customer_PromotionVM> request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.AddAsync(request));
		}

		// PUT api/<Customer_PromotionController>/5
		[HttpPut("update/{idcustomer}/{idpromotion}")]
		public async Task<IActionResult> UpdateAsync([FromBody] Customer_PromotionVM request)
		{
			if (request == null) return BadRequest();
			return Ok(await _service.UpdateAsync(request));
		}

		// DELETE api/<Customer_PromotionController>/5
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteAsync(Guid idcustomer, Guid idpromotion)
		{
			var obj = await _service.GetByIdAsync(idcustomer, idpromotion);
			if (obj == null) return NotFound();
			return Ok(await _service.DeleteAsync(idcustomer, idpromotion));
		}
	}
}
