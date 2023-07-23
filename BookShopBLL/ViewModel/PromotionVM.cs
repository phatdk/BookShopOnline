using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.ViewModel
{
	public class PromotionVM
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public int? Condition { get; set; }
		public int? ReduceAmount { get; set; }
		public float? ReduceRate { get; set; }
		public int ReduceMax { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string? Description { get; set; }
		public int Status { get; set; }

		// foreignkey
		public Guid Id_PromotionType { get; set; }
	}
}
