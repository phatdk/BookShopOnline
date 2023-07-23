using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IBrandService
	{
		public Task<List<BrandVM>> GetAsync(string? name);
		public Task<List<BrandVM>> GetActiveAsync(string? name);
		public Task<BrandVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(BrandVM item);
		public Task<bool> UpdateAsync(BrandVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
