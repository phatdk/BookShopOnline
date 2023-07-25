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
		[Required, MaxLength(50)]
		public string ShopName { get; set; }
		[Required, EmailAddress]
		public string EmailAddress { get; set; }
		[Required, MaxLength(13)]
		public string Phones { get; set; }
		[Required, MaxLength(100)]
		public string Address { get; set; }
		public DateTime CreatedDate { get; set; }
		[Required]
		public int Status { get; set; }
	}
}
