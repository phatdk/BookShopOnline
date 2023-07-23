using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class Promotion_TypeVM
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
