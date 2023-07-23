using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Admin
	{
		public Guid Id { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		public DateTime CreatedDate { get; set; }
		[Required]
		public int Status { get; set; }
	}
}
