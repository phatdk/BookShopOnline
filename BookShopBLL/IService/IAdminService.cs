using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IAdminService
	{
		public Task<List<AdminVM>> GetAsync();
		public Task<List<AdminVM>> GetActiveAsync();
		public Task<AdminVM> GetByIdAsync(Guid? Id, string? email, int status);
		public Task<bool> AddAsync(AdminVM item);
		public Task<bool> UpdateAsync(AdminVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
