using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Image
	{
		public Guid Id { get; set; }
		[Required, MaxLength(100, ErrorMessage = "The path exceeds 100 characters, please change the image name")]
		public string ImageUrl { get; set; }
		[Required]
		public int? Index { get; set; }
		public DateTime CreatedDate { get; set; }

		// foreignkey
		public Guid Id_Parents  { get; set;}
		public virtual Shop shop { get; set; }
		public virtual Book book { get; set; }
		public virtual Publisher publisher { get; set; }
		public virtual Author author { get; set; }
	}
}
