using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class Order_BookVM
	{
		public Guid Id_Order { get; set; }
		public Guid Id_Book { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }
		public int Status { get; set; }
	}
}
