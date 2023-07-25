using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class NewsVM
	{
		public Guid Id { get; set; }
		[Required, MaxLength(100)]
		public string Title { get; set; }
		[Required]
		public string Content { get; set; }
		[MaxLength(256)]
		public string? Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
