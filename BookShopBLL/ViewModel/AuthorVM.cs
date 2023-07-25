using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class AuthorVM
	{
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
		[Required]
		public int? Index { get; set; }
		[Required]
		public int? Gender { get; set; }
		[Required]
		public string? Birth { get; set; }
		[MaxLength(100)]
		public string? Address { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

	}
}
