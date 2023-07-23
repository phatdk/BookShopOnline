using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Customer
	{
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
		[Required]
		public DateTime? Birth { get; set; }
		[Required]
		public int? Gender { get; set; }
		[Required]
		public string Address { get; set; }
		[Required, MaxLength(13)]
		public string Phones { get; set; }
		public int WalletPoint { get; set; } = 0;
		[Required, EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public DateTime CreatedDate { get; set; }
		[Required]
		public int Status { get; set; }

		// reference
		public virtual List<Delivery_Address> delivery_Addresses { get; set; }
		public virtual List<Order> orders { get; set; }
		public virtual List<WishList> wishLists { get; set; }
		public virtual List<Cart> carts { get; set; }
		public virtual List<Evaluate> evaluates { get; set; }
		public virtual List<Comment> comments { get; set; }
		public virtual List<Customer_Promotion> customer_Promotions { get; set; }
	}
}
