namespace BookShopDAL.Entity
{
	public class Order_Book
	{
		public Guid Id_Order { get; set; }
		public Guid Id_Book { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }
		public int Status { get; set; }

		//foreignkey
		public virtual Order order { get; set; }
		public virtual Book book { get; set; }
	}
}
