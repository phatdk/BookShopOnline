using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class BookVM
	{
		public Guid Id { get; set; }
		public string? ISBN { get; set; }
		public string Title { get; set; }
		public int Price { get; set; }
		public int ImportPrice { get; set; }
		public string Reader { get; set; }
		public int Quantity { get; set; }
		public int Pages { get; set; }
		public DateTime PublicationDate { get; set; }
		public string PageSize { get; set; }
		public string Cover { get; set; }
		public float Weight { get; set; }
		public string? Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }
		public Guid Id_Publisher { get; set; }
		public Guid Id_Genre { get; set; }
		public Guid? Id_Brand { get; set; }
		public Guid? Id_Collection { get; set; }
	}
}
