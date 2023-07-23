using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IAuthorService
	{
		public Task<List<AuthorVM>> GetAsync(string? name);
		public Task<List<AuthorVM>> GetActiveAsync(string? name);
		public Task<AuthorVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(AuthorVM item);
		public Task<bool> UpdateAsync(AuthorVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
