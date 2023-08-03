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
	public class ReturnOrderService : IReturnOrderService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public ReturnOrderService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(ReturnOrderVM item)
		{
			try
			{
				var obj = new ReturnOrder()
				{
					Id = item.Id,
					Notes = item.Notes,
					CreatedDate = DateTime.Now,
					Status = 1,
					Id_Order = item.Id_Order,
				};
				await _context.ReturnOrders.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.ReturnOrders.FindAsync(Id);
				await Task.FromResult<ReturnOrder>(_context.ReturnOrders.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<ReturnOrderVM>> GetAsync(Guid? IdOrder)
		{
			if (IdOrder != null)
			{
				return await _context.ReturnOrders.ProjectTo<ReturnOrderVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Order == IdOrder).ToListAsync();
			}
			return await _context.ReturnOrders.ProjectTo<ReturnOrderVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<ReturnOrderVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.ReturnOrders.ProjectTo<ReturnOrderVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}catch(Exception e) { return null; }
		}

		public async Task<bool> UpdateAsync(ReturnOrderVM item)
		{
			try
			{
				var obj = await _context.ReturnOrders.FindAsync(item.Id);
				obj.Notes = item.Notes;
				obj.Status = item.Status;

				await Task.FromResult<ReturnOrder>(_context.ReturnOrders.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
