using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface ICollection_BookService
	{
		public Task<List<Collection_BookVM>> GetAsync(string? name);
		public Task<List<Collection_BookVM>> GetActiveAsync(string? name);
		public Task<Collection_BookVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(Collection_BookVM item);
		public Task<bool> UpdateAsync(Collection_BookVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
