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
	public class Order_BookService : IOrder_BookService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public Order_BookService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		
		public async Task<bool> AddAsync(List<Order_BookVM> list)
		{
			try
			{
				var listobj = new List<Order_Book>();
				foreach (var item in list)
				{
					var obj = new Order_Book()
					{
						Id_Book = item.Id_Book,
						Id_Order = item.Id_Order,
						Quantity = item.Quantity,
						Price = item.Price,
						Status = 1,
					};
					listobj.Add(obj);
				}

				await _context.Order_Books.AddRangeAsync(listobj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid IdOrder, Guid? IdBook)
		{
			try
			{
				if (IdBook == null)
				{
					var obj = await _context.Order_Books.Where(c => c.Id_Order == IdOrder).ToListAsync();
					 _context.Order_Books.RemoveRange(obj);
					await _context.SaveChangesAsync();
				}
				else
				{
					var obj = _context.Order_Books.First(c => c.Id_Order == IdOrder && c.Id_Book == IdBook);
					await Task.FromResult<Order_Book>(_context.Order_Books.Remove(obj).Entity);
					await _context.SaveChangesAsync();
				}
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<Order_BookVM>> GetAsync(Guid? IdOrder, Guid? IdBook)
		{
			if (IdOrder != null && IdBook == null)
			{
				return await _context.Order_Books.ProjectTo<Order_BookVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Order == IdOrder).ToListAsync();
			}
			else if (IdBook != null && IdOrder == null)
			{
				return await _context.Order_Books.ProjectTo<Order_BookVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Book == IdBook).ToListAsync();
			}
			return await _context.Order_Books.ProjectTo<Order_BookVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<Order_BookVM> GetByIdAsync(Guid IdOrder, Guid? IdBook)
		{
			try
			{
				return await _context.Order_Books.ProjectTo<Order_BookVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id_Book == IdBook && c.Id_Order == IdOrder);
			}catch { return null; }
		}

		public async Task<bool> UpdateAsync(Order_BookVM item)
		{
			try
			{
				var obj = await _context.Order_Books.FirstAsync(c => c.Id_Order == item.Id_Order && c.Id_Book == item.Id_Book);
				obj.Id_Book = item.Id_Book;
				obj.Id_Order = item.Id_Order;
				obj.Quantity = item.Quantity;
				obj.Price = item.Price;
				obj.Status = item.Status;

				await Task.FromResult<Order_Book>(_context.Order_Books.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
