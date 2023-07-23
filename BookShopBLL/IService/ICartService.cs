using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface ICartService
	{
		public Task<List<CartVM>> GetAsync(Guid? IdCustomer, Guid? IdBook);
		public Task<CartVM> GetByIdAsync(Guid IdCustomer, Guid IdBook);
		public Task<bool> AddAsync(CartVM item);
		public Task<bool> UpdateAsync(CartVM item);
		public Task<bool> DeleteAsync(Guid IdCustomer, Guid IdBook);
	}
}
