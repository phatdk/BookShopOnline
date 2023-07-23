using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class ReturnOrder
	{
		public Guid Id { get; set; }
		[Required, MaxLength(256)]
		public string Notes { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		//foreignkey
		public Guid Id_Order { get; set; }
		public virtual Order order { get; set; }
	}
}
