using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Author
	{
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
		[Required]
		public int? Index { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		// reference
		public virtual List<Book_Author> book_Authors { get; set; }
	}
}
