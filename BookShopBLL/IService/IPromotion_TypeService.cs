using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IPromotion_TypeService
	{
		public Task<List<Promotion_TypeVM>> GetAsync();
		public Task<List<Promotion_TypeVM>> GetActiveAsync();
		public Task<Promotion_TypeVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(Promotion_TypeVM item);
		public Task<bool> UpdateAsync(Promotion_TypeVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
