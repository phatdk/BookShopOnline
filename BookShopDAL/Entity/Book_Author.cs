namespace BookShopDAL.Entity
{
	public class Book_Author
	{
		public Guid Id_Book { get; set; }
		public Guid Id_Author { get; set; }

		//reference
		public virtual Book book { get; set; }
		public virtual Author author { get; set; }
	}
}
