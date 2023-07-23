using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IShopService
	{
		public Task<List<ShopVM>> GetAsync();
		public Task<ShopVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(ShopVM item);
		public Task<bool> UpdateAsync(ShopVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
