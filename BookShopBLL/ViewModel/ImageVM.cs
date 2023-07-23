using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class ImageVM
	{

		public Guid Id { get; set; }
		public string ImageUrl { get; set; }
		public int? Index { get; set; }
		public DateTime CreatedDate { get; set; }

		// foreignkey
		public Guid Id_Parents { get; set; }
	}
}
