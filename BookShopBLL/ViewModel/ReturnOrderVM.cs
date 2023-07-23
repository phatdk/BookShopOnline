using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class ReturnOrderVM
	{
		public Guid Id { get; set; }
		public string Notes { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		//foreignkey
		public Guid Id_Order { get; set; }
	}
}
