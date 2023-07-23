using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Comment
	{
		public Guid Id { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }

		// foreignkey
		public Guid? Id_Customer { get; set; }
		public Guid? Id_Book { get; set; }
		public Guid? Id_Parents { get; set; }
		public virtual Customer? customer { get; set; }
		public virtual Book? book { get; set; }
		public virtual Evaluate? evaluate { get; set; }
		public virtual Comment? comment { get; set; }

		//reference
		public virtual List<Comment> comments { get; set; }
	}
}
