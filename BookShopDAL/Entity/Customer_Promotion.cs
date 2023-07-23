namespace BookShopDAL.Entity
{
	public class Customer_Promotion
	{
		public Guid Id_Customer { get; set; }
		public Guid Id_Promotion { get; set; }
		public DateTime? EndDate { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		//foreignkey
		public virtual Customer customer { get; set; }
		public virtual Promotion promotion { get; set; }
	}
}
