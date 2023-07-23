using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IReturnOrderService
	{
		public Task<List<ReturnOrderVM>> GetAsync(Guid? IdOrder);
		public Task<ReturnOrderVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(ReturnOrderVM item);
		public Task<bool> UpdateAsync(ReturnOrderVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
