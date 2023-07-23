using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IBook_PromotionService
	{
		public Task<List<Book_PromotionVM>> GetAsync(Guid? IdBook, Guid? IdPromotion);
		public Task<List<Book_PromotionVM>> GetActiveAsync(Guid? IdBook, Guid? IdPromotion);
		public Task<Book_PromotionVM> GetByIdAsync(Guid? IdBook, Guid? IdPromotion);
		public Task<bool> AddAsync(List<Book_PromotionVM> item);
		public Task<bool> UpdateAsync(Book_PromotionVM item);
		public Task<bool> DeleteAsync(Guid? IdBook, Guid? IdPromotion);
	}
}
