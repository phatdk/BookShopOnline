using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class CartVM
	{
		public Guid Id_Customer { get; set; }
		public Guid Id_Book { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Quantity { get; set; }
	}
}
