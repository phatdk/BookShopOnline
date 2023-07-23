namespace BookShopDAL.Entity
{
	public class Book_Promotion
	{
		public Guid Id_Book { get; set; }
		public Guid Id_Promotion { get; set; }
		public int? Index { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		//foreignkey
		public virtual Book book { get; set; }
		public virtual Promotion promotion { get; set; }
	}
}
