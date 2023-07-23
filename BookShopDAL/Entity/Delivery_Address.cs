using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Delivery_Address
	{
		public Guid Id { get; set; }
		[Required]
		public string Address { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		// foreignkey
		public Guid Id_Customer { get; set; }
		public virtual Customer customer { get; set; }

		// reference
		public virtual List<Order> orders { get; set; }
	}
}
