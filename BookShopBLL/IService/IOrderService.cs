using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IOrderService
	{
		public Task<List<OrderVM>> GetAsync(Guid? IdCustomer);
		public Task<List<OrderVM>> GetActiveAsync(Guid? IdCustomer, int? status);
		public Task<OrderVM> GetByIdAsync(Guid? Id, string? code);
		public Task<bool> AddAsync(OrderVM item);
		public Task<bool> UpdateAsync(OrderVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
