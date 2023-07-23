using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class Delivery_AddressVM
	{
		public Guid Id { get; set; }
		public string Address { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		// foreignkey
		public Guid Id_Customer { get; set; }
	}
}
