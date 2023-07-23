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
	public class WishListService : IWishListService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public WishListService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(WishListVM item)
		{
			try
			{
				var obj = new WishList()
				{
					Id_Book = item.Id_Book,
					Id_Customer = item.Id_Customer,
				};
				await _context.WishLists.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid IdCustomer, Guid IdBook)
		{
			try
			{
				var obj = await _context.WishLists.FirstAsync(c => c.Id_Book == IdBook && c.Id_Customer == IdCustomer);
				await Task.FromResult<WishList>(_context.WishLists.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<WishListVM>> GetAsync(Guid? IdCustomer, Guid? IdBook)
		{
			if (IdCustomer != Guid.Empty || IdCustomer != null && IdBook == null)
			{
				return await _context.WishLists.ProjectTo<WishListVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer).ToListAsync();
			}
			else if (IdBook != Guid.Empty || IdBook != null && IdCustomer == null)
			{
				return await _context.WishLists.ProjectTo<WishListVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Book == IdBook).ToListAsync();
			}
			return await _context.WishLists.ProjectTo<WishListVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<WishListVM> GetByIdAsync(Guid IdCustomer, Guid IdBook)
		{
			return await _context.WishLists.ProjectTo<WishListVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id_Customer == IdCustomer && c.Id_Book == IdBook);
		}

		public async Task<bool> UpdateAsync(WishListVM item)
		{
			try
			{
				var obj = await _context.WishLists.FirstAsync(c => c.Id_Customer == item.Id_Customer && c.Id_Book == item.Id_Book);
				obj.Id_Book = item.Id_Book;
				obj.Id_Customer = item.Id_Customer;

				await Task.FromResult<WishList>(_context.WishLists.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
