using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IGenreService
	{
		public Task<List<GenreVM>> GetAsync(string? name);
		public Task<List<GenreVM>> GetActiveAsync(string? name);
		public Task<GenreVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(GenreVM item);
		public Task<bool> UpdateAsync(GenreVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
