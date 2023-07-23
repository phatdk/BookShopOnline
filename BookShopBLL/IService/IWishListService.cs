using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IWishListService
	{
		public Task<List<WishListVM>> GetAsync(Guid? IdCustomer, Guid? IdBook);
		public Task<WishListVM> GetByIdAsync(Guid IdCustomer, Guid IdBook);
		public Task<bool> AddAsync(WishListVM item);
		public Task<bool> UpdateAsync(WishListVM item);
		public Task<bool> DeleteAsync(Guid IdCustomer, Guid IdBook);
	}
}
