using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface ICustomer_PromotionService
	{
		public Task<List<Customer_PromotionVM>> GetAsync(Guid? IdCustomer, Guid? IdPromotion);
		public Task<List<Customer_PromotionVM>> GetActiveAsync(Guid? IdCustomer, Guid? IdPromotion);
		public Task<Customer_PromotionVM> GetByIdAsync(Guid IdCustomer, Guid IdPromotion);
		public Task<bool> AddAsync(List<Customer_PromotionVM> list);
		public Task<bool> UpdateAsync(Customer_PromotionVM item);
		public Task<bool> DeleteAsync(Guid IdCustomer, Guid IdPromotion);
	}
}
