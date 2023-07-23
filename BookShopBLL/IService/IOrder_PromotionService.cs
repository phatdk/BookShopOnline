using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IOrder_PromotionService
	{
		public Task<List<Order_PromotionVM>> GetAsync(Guid? IdOrder, Guid? IdPromotion);
		public Task<Order_PromotionVM> GetByIdAsync(Guid IdOrder, Guid IdPromotion);
		public Task<bool> AddAsync(List<Order_PromotionVM> list);
		public Task<bool> UpdateAsync(Order_PromotionVM item);
		public Task<bool> DeleteAsync(Guid IdOrder, Guid? IdPromotion);
	}
}
