﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class Book_PromotionVM
	{
		public Guid Id_Book { get; set; }
		public Guid Id_Promotion { get; set; }
		public int? Index { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
	}
}
