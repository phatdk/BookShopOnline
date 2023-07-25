using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class EvaluateVM
	{
		public Guid Id { get; set; }
		[Required, Range(1, 5)]
		public int Point { get; set; }
		[MaxLength(256)]
		public string? Content { get; set; }
		public DateTime CreatedDate { get; set; }
		public int status { get; set; }

		//foreignkey
		public Guid Id_Customer { get; set; }
		public Guid Id_Book { get; set; }

	}
}
