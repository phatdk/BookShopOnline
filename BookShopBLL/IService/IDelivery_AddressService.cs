using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IDelivery_AddressService
	{
		public Task<List<Delivery_AddressVM>> GetAsync(Guid? IdCustomer);
		public Task<List<Delivery_AddressVM>> GetActiveAsync(Guid? IdCustomer);
		public Task<Delivery_AddressVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(Delivery_AddressVM item);
		public Task<bool> UpdateAsync(Delivery_AddressVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
