using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface ICustomerService
	{
		public Task<List<CustomerVM>> GetAsync(string? name);
		public Task<List<CustomerVM>> GetActiveAsync(string? name);
		public Task<CustomerVM> GetByIdAsync(Guid? Id, string? email, int status);
		public Task<bool> AddAsync(CustomerVM item);
		public Task<bool> UpdateAsync(CustomerVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
