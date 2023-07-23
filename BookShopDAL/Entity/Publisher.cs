using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Publisher
	{
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
		public int? Index { get; set; }
		public string? Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
		
		//reference
		public virtual List<Book> books { get; set; }
		public virtual List<Image> images { get; set; }
	}
}
