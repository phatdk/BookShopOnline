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
		[Required, MaxLength(50)]
		public string Name { get; set; }
		[Required]
		public DateTime? Birth { get; set; }
		[Required]
		public int? Gender { get; set; }
		[Required]
		public string Address { get; set; }
		[Required, MaxLength(13)]
		public string Phones { get; set; }
		public int WalletPoint { get; set; } = 0;
		[Required, EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public DateTime CreatedDate { get; set; }
		[Required]
		public int Status { get; set; }
	}
}
