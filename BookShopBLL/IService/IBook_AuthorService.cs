using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IBook_AuthorService
	{
		public Task<List<Book_AuthorVM>> GetAsync(Guid? IdBook, Guid? IdAuthor);
		public Task<Book_AuthorVM> GetByIdAsync(Guid IdBook, Guid? IdAuthor);
		public Task<bool> AddAsync(List<Book_AuthorVM> list);
		public Task<bool> UpdateAsync(Book_AuthorVM list);
		public Task<bool> DeleteAsync(Guid IdBook, Guid? IdAuthor);
	}
}
