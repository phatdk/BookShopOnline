using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Promotion
	{
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
		public string Code { get; set; }
		public int? Condition { get; set; }
		[Range(0, 1000000000)]
		public int? ReduceAmount { get; set; }
		[Range(1, 100)]
		public float? ReduceRate { get; set; }
		public int ReduceMax { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		[MaxLength(256)]
		public string? Description { get; set; }
		public int Status { get; set; }

		// foreignkey
		public Guid Id_PromotionType { get; set; }
		public virtual Promotion_Type promotion_Type { get; set; }

		// reference 
		public virtual List<Customer_Promotion> customer_Promotions { get; set; }
		public virtual List<Order_Promotion> order_Promotions { get; set; }
		public virtual List<Book_Promotion> book_Promotions { get; set; }
	}
}
