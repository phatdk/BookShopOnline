namespace BookShopDAL.Entity
{
	public class WishList
	{
		public Guid Id_Customer { get; set; }
		public Guid Id_Book { get; set; }
		public DateTime CreatedDate { get; set; }

		//reference
		public virtual Customer customer { get; set; }
		public virtual Book book { get; set; }
	}
}
