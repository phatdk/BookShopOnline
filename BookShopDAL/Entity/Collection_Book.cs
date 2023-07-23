using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Collection_Book
	{
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		// reference
		public virtual List<Book> books { get; set; }
	}
}
