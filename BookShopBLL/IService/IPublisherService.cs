using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IPublisherService
	{
		public Task<List<PublisherVM>> GetAsync(string? name);
		public Task<List<PublisherVM>> GetActiveAsync(string? name);
		public Task<PublisherVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(PublisherVM item);
		public Task<bool> UpdateAsync(PublisherVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
