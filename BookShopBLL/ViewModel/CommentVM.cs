using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class CommentVM
	{
		public Guid Id { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }

		// foreignkey
		public Guid? Id_Customer { get; set; }
		public Guid? Id_Book { get; set; }
		public Guid? Id_Parents { get; set; }
	}
}
