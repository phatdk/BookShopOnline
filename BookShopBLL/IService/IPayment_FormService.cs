using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IPayment_FormService
	{
		public Task<List<Payment_FormVM>> GetAsync();
		public Task<List<Payment_FormVM>> GetActiveAsync();
		public Task<Payment_FormVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(Payment_FormVM item);
		public Task<bool> UpdateAsync(Payment_FormVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
