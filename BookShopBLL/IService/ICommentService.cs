using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface ICommentService
	{
		public Task<List<CommentVM>> GetAsync(Guid? IdBook, Guid? IdCustommer, Guid? IdParents);
		public Task<CommentVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(CommentVM item);
		public Task<bool> UpdateAsync(CommentVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
