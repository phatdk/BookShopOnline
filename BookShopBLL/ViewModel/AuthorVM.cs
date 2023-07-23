using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class AuthorVM
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int? Index { get; set; }
		public int? Gender { get; set; }
		public string? Birth { get; set; }
		public string? Address { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
