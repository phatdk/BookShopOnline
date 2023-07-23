using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Shop
	{
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string ShopName { get; set; }
		[Required, EmailAddress]
		public string EmailAddress { get; set; }
		[Required, MaxLength(13)]
		public string Phones { get; set; }
		[Required, MaxLength(100)]
		public string Address { get; set; }
		public DateTime CreatedDate { get; set; }
		[Required]
		public int Status { get; set; }

		// reference
		public virtual List<Image> images { get; set; }
	}
}
