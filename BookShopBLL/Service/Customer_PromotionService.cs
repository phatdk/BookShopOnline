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
	public class Customer_PromotionService : ICustomer_PromotionService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public Customer_PromotionService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(List<Customer_PromotionVM> list)
		{
			try
			{
				var listobj = new List<Customer_Promotion>();
				foreach (var item in list)
				{
					var obj = new Customer_Promotion()
					{
						Id_Customer = item.Id_Customer,
						Id_Promotion = item.Id_Promotion,
						EndDate = item.EndDate,
						CreatedDate = DateTime.Now,
						Status = 1,
					};
					listobj.Add(obj);
				}
				await _context.Customer_Promotions.AddRangeAsync(listobj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid IdCustomer, Guid IdPromotion)
		{
			try
			{
				var obj = await _context.Customer_Promotions.FirstAsync(c => c.Id_Customer == IdCustomer && c.Id_Promotion == IdPromotion);
				await Task.FromResult<Customer_Promotion>(_context.Customer_Promotions.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<Customer_PromotionVM>> GetActiveAsync(Guid? IdCustomer, Guid? IdPromotion)
		{
			if (IdCustomer != null && IdPromotion == null)
			{
				return await _context.Customer_Promotions.ProjectTo<Customer_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer && c.Status == 1).ToListAsync();
			}
			else if (IdPromotion != null && IdCustomer == null)
			{
				return await _context.Customer_Promotions.ProjectTo<Customer_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Promotion == IdPromotion && c.Status == 1).ToListAsync();
			}
			else return await _context.Customer_Promotions.ProjectTo<Customer_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<Customer_PromotionVM>> GetAsync(Guid? IdCustomer, Guid? IdPromotion)
		{
			if (IdCustomer != null && IdPromotion == null)
			{
				return await _context.Customer_Promotions.ProjectTo<Customer_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer).ToListAsync();
			}
			else if (IdPromotion != null && IdCustomer == null)
			{
				return await _context.Customer_Promotions.ProjectTo<Customer_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Promotion == IdPromotion).ToListAsync();
			}
			else return await _context.Customer_Promotions.ProjectTo<Customer_PromotionVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<Customer_PromotionVM> GetByIdAsync(Guid IdCustomer, Guid IdPromotion)
		{
			return await _context.Customer_Promotions.ProjectTo<Customer_PromotionVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id_Customer == IdCustomer && c.Id_Promotion == IdPromotion);
		}

		public async Task<bool> UpdateAsync(Customer_PromotionVM item)
		{
			try
			{
				var obj = await _context.Customer_Promotions.FirstAsync(c => c.Id_Promotion == item.Id_Promotion && c.Id_Customer == item.Id_Customer);
				obj.Id_Customer = item.Id_Customer;
				obj.Id_Promotion = item.Id_Promotion;
				obj.EndDate = item.EndDate;
				obj.Status = item.Status;

				await Task.FromResult<Customer_Promotion>(_context.Customer_Promotions.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
