using BookShopBLL.ViewModel;
using BookShopDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.IService
{
	public interface IImageService
	{
		public Task<List<ImageVM>> GetAsync(Guid? IdParents);
		public Task<ImageVM> GetByIdAsync(Guid Id);
		public Task<bool> AddAsync(ImageVM item);
		public Task<bool> UpdateAsync(ImageVM item);
		public Task<bool> DeleteAsync(Guid Id);
	}
}
