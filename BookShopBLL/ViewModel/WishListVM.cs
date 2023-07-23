using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class WishListVM
	{
		public Guid Id_Customer { get; set; }
		public Guid Id_Book { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
