using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class News
	{
		public Guid Id { get; set; }
		[Required, MaxLength(100)]
		public string Title { get; set; }
		[Required]
		public string Content { get; set; }
		[MaxLength(256)]
		public string? Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
