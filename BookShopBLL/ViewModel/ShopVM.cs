using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class ShopVM
	{
		public Guid Id { get; set; }
		public string ShopName { get; set; }
		public string EmailAddress { get; set; }
		public string Phones { get; set; }
		public string Address { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
