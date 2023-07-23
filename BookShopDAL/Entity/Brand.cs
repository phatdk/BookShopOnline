using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL.Entity
{
	public class Brand
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Status { get; set; }

		//reference
		public List<Book> books { get; set; }
	}
}
