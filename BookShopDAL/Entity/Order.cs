using System.ComponentModel.DataAnnotations;

namespace BookShopDAL.Entity
{
	public class Order
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		[Required, MaxLength(50)]
		public string Receiver { get; set; }
		[Required, MaxLength(13)]
		public string Phones { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? AcceptDate { get; set; }
		public DateTime? DeliveryDate { get; set; }
		public DateTime? ReceiveDate { get; set; }
		public DateTime? PaymentDate { get; set;}
		public DateTime? CompleteDate { get;set; }
		public DateTime? ModifyDate { get; set; }
		public string? ModifyNotes { get; set; }
		public int DeliveryCharges { get; set; }
		public int Status { get; set; }

		//foreignkey
		public Guid Id_Address { get; set; }
		public Guid Id_Customer { get; set; }
		public Guid Id_PaymentForm { get; set; }
		public virtual Customer customer { get; set; }
		public virtual Delivery_Address delivery_address { get; set; }
		public virtual Payment_Form payment_Form { get; set; }

		//reference
		public virtual List<Order_Book> order_Books { get; set; }
		public virtual List<Order_Promotion> order_Promotions { get; set; }
		public virtual List<ReturnOrder> returnOrders { get; set; }
	}
}
