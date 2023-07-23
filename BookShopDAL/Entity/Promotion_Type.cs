using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Promotion_Type
	{
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		//reference
		public virtual List<Promotion> promotions { get; set; }
	}
}
