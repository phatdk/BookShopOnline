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
	public class Order_PromotionService : IOrder_PromotionService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public Order_PromotionService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(List<Order_PromotionVM> list)
		{
			try
			{
				var listobj = new List<Order_Promotion>();
				foreach (var item in list)
				{
					var obj = new Order_Promotion()
					{
						Id_Order = item.Id_Order,
						Id_Promotion = item.Id_Promotion,
						ReduceAmount = item.ReduceAmount,
						ReduceMax = item.ReduceMax,
					};
					listobj.Add(obj);
				}
				await _context.Order_Promotions.AddRangeAsync(listobj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid IdOrder, Guid? IdPromotion)
		{
			try
			{
				if (IdOrder != null && IdPromotion == null)
				{
					var obj = await _context.Order_Promotions.Where(c => c.Id_Order == IdOrder).ToListAsync();
					_context.Order_Promotions.RemoveRange(obj);
					await _context.SaveChangesAsync();
				}
				else
				{
					var obj = _context.Order_Promotions.First(c => c.Id_Order == IdOrder && c.Id_Promotion == IdPromotion);
					await Task.FromResult<Order_Promotion>(_context.Order_Promotions.Remove(obj).Entity);
					await _context.SaveChangesAsync();
				}
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<Order_PromotionVM>> GetAsync(Guid? IdOrder, Guid? IdPromotion)
		{
			if (IdOrder != null && IdPromotion == null)
			{
				return await _context.Order_Promotions.ProjectTo<Order_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Order == IdOrder).ToListAsync();
			}
			else if (IdPromotion != null && IdOrder == null)
			{
				return await _context.Order_Promotions.ProjectTo<Order_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Promotion == IdPromotion).ToListAsync();
			}
			return await _context.Order_Promotions.ProjectTo<Order_PromotionVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<Order_PromotionVM> GetByIdAsync(Guid IdOrder, Guid IdPromotion)
		{
			return await _context.Order_Promotions.ProjectTo<Order_PromotionVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id_Order == IdOrder && c.Id_Promotion == IdPromotion);
		}

		public async Task<bool> UpdateAsync(Order_PromotionVM item)
		{
			try
			{
				var obj = await _context.Order_Promotions.FirstAsync(c => c.Id_Promotion == item.Id_Promotion && c.Id_Order == item.Id_Order);
				obj.Id_Order = item.Id_Order;
				obj.Id_Promotion = item.Id_Promotion;
				obj.ReduceMax = item.ReduceMax;
				obj.ReduceAmount = item.ReduceAmount;

				await Task.FromResult<Order_Promotion>(_context.Order_Promotions.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
