using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Cart
	{
		public Guid Id_Customer { get; set; }
		public Guid Id_Book { get; set; }
		public DateTime CreatedDate { get; set; }
		[Required]
		public int Quantity { get; set; } = 1;

		//reference 
		public virtual Customer customer { get; set; }
		public virtual Book book { get; set; }
	}
}
