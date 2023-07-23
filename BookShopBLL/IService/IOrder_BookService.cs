using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IOrder_BookService
	{
		public Task<List<Order_BookVM>> GetAsync(Guid? IdOrder, Guid? IdBook);
		public Task<Order_BookVM> GetByIdAsync(Guid IdOrder, Guid? IdBook);
		public Task<bool> AddAsync(List<Order_BookVM> list);
		public Task<bool> UpdateAsync(Order_BookVM item);
		public Task<bool> DeleteAsync(Guid IdOrder, Guid? IdBook);
	}
}
