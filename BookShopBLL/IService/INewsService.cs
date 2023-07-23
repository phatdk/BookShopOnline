using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface INewsService
	{
		public Task<List<NewsVM>> GetAsync();
		public Task<NewsVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(NewsVM item);
		public Task<bool> UpdateAsync(NewsVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
