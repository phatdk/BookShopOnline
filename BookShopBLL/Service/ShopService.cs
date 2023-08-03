using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using BookShopDAL.ApplicationDBContext;
using BookShopDAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.Service
{
	public class ShopService : IShopService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public ShopService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async  Task<bool> AddAsync(ShopVM item)
		{
			try
			{
				var obj = new Shop()
				{
					Id = item.Id,
					ShopName = item.ShopName,
					EmailAddress = item.EmailAddress,
					Phones = item.Phones,
					Address = item.Address,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Shops.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public  async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Shops.FindAsync(Id);
				await Task.FromResult<Shop>(_context.Shops.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<ShopVM>> GetAsync()
		{

			return await _context.Shops.ProjectTo<ShopVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public  async Task<ShopVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.Shops.ProjectTo<ShopVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}catch(Exception e) { return null; }
		}

		public  async Task<bool> UpdateAsync(ShopVM item)
		{
			try
			{
				var obj = await _context.Shops.FindAsync(item.Id);
				obj.ShopName = item.ShopName;
				obj.EmailAddress = item.EmailAddress;
				obj.Phones = item.Phones;
				obj.Address = item.Address;
				obj.Status = item.Status;

				await Task.FromResult<Shop>(_context.Shops.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
