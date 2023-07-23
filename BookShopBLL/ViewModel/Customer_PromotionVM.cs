using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class Customer_PromotionVM
	{
		public Guid Id_Customer { get; set; }
		public Guid Id_Promotion { get; set; }
		public DateTime? EndDate { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
