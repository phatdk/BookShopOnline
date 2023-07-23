using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IEvaluateService
	{
		public Task<List<EvaluateVM>> GetAsync(Guid? IdBook, Guid? IdCustomer);
		public Task<EvaluateVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(EvaluateVM item);
		public Task<bool> UpdateAsync(EvaluateVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
