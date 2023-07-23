using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Evaluate
	{
		public Guid Id { get; set; }
		[Required, Range(1, 5)]
		public int Point { get; set; }
		[MaxLength(256)]
		public string? Content { get; set; }
		public DateTime CreatedDate { get; set; }
		public int status { get; set; }

		//foreignkey
		public Guid Id_Customer { get; set; }
		public Guid Id_Book { get; set; }
		public virtual Customer customer { get; set; }
		public virtual Book book { get; set; }

		//reference
		public virtual List<Comment> comments { get; set; }
	}
}
