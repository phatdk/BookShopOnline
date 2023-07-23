namespace BookShopDAL.Entity
{
	public class Order_Promotion
	{
		public Guid Id_Order { get; set; }
		public Guid Id_Promotion { get; set; }
		public int ReduceAmount { get; set; }
		public int ReduceMax { get; set;}

		//foreignkey
		public virtual Order order { get; set; }
        public virtual Promotion promotion { get; set; }
    }
}
