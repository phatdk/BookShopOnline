using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IPromotionService
	{
		public Task<List<PromotionVM>> GetAsync(Guid? IdType);
		public Task<List<PromotionVM>> GetActiveAsync(Guid? IdType);
		public Task<PromotionVM> GetByIdAsync(Guid? Id, string? code);
		public Task<bool> AddAsync(PromotionVM item);
		public Task<bool> UpdateAsync(PromotionVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
