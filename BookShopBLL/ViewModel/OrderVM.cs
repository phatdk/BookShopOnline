using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class OrderVM
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		public string Receiver { get; set; }
		public string Phones { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? AcceptDate { get; set; }
		public DateTime? DeliveryDate { get; set; }
		public DateTime? ReceiveDate { get; set; }
		public DateTime? PaymentDate { get; set; }
		public DateTime? CompleteDate { get; set; }
		public DateTime? ModifyDate { get; set; }
		public string? ModifyNotes { get; set; }
		public int DeliveryCharges { get; set; }
		public int Status { get; set; }

		//foreignkey
		public Guid Id_Address { get; set; }
		public Guid Id_Customer { get; set; }
		public Guid Id_PaymentForm { get; set; }
	}
}
