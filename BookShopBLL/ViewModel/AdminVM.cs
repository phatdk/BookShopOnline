using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class AdminVM
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
