using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IBookService
	{
		public Task<List<BookVM>> GetAsync(string? name);
		public Task<List<BookVM>> GetActiveAsync(string? name);
		public Task<BookVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(BookVM item);
		public Task<bool> UpdateAsync(BookVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
