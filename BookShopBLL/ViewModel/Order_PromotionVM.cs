using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class Order_PromotionVM
	{
		public Guid Id_Order { get; set; }
		public Guid Id_Promotion { get; set; }
		public int ReduceAmount { get; set; }
		public int ReduceMax { get; set; }
	}
}
