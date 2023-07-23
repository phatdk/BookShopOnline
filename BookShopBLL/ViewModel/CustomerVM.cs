using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class CustomerVM
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime? Birth { get; set; }
		public int? Gender { get; set; }
		public string Address { get; set; }
		public string Phones { get; set; }
		public int WalletPoint { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
