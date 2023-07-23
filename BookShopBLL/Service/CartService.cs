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
	public class CartService : ICartService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public CartService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(CartVM item)
		{
			try
			{
				var obj = new Cart()
				{
					Id_Book = item.Id_Book,
					Id_Customer = item.Id_Customer,
					CreatedDate = DateTime.Now,
					Quantity = item.Quantity,
				};
				await _context.Carts.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid IdCustomer, Guid IdBook)
		{
			try
			{
				var obj = await _context.Carts.FirstAsync(c => c.Id_Customer == IdCustomer && c.Id_Book == IdBook);
				await Task.FromResult<Cart>(_context.Carts.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<CartVM>> GetAsync(Guid? IdCustomer, Guid? IdBook)
		{
			if (IdCustomer != Guid.Empty || IdCustomer != null && IdBook == null)
			{
				return await _context.Carts.ProjectTo<CartVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer).ToListAsync();
			}
			else if (IdBook != Guid.Empty || IdBook != null && IdCustomer == null)
			{
				return await _context.Carts.ProjectTo<CartVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Book == IdBook).ToListAsync();
			}
			return await _context.Carts.ProjectTo<CartVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<CartVM> GetByIdAsync(Guid IdCustomer, Guid IdBook)
		{
			return await _context.Carts.ProjectTo<CartVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id_Customer == IdCustomer && c.Id_Book == IdBook);
		}

		public async Task<List<CartVM>> GetListByIdAsync(Guid? IdCustomer, Guid? IdBook)
		{
			if (IdBook == Guid.Empty || IdBook == null)
			{
				return await _context.Carts.ProjectTo<CartVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer).ToListAsync();
			}
			else
			{
				return await _context.Carts.ProjectTo<CartVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Book == IdBook).ToListAsync();
			}
		}

		public async Task<bool> UpdateAsync(CartVM item)
		{
			try
			{
				var obj = await _context.Carts.FirstAsync(c => c.Id_Book == item.Id_Book && c.Id_Customer == item.Id_Customer);
				obj.Id_Customer = item.Id_Customer;
				obj.Id_Book = item.Id_Book;
				obj.Quantity = item.Quantity;

				await Task.FromResult<Cart>(_context.Carts.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
