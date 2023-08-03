using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using BookShopDAL.ApplicationDBContext;
using BookShopDAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.Service
{
	public class PromotionService : IPromotionService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public PromotionService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(PromotionVM item)
		{
			try
			{
				var obj = new Promotion()
				{
					Id = item.Id,
					Name = item.Name,
					Code = item.Code,
					Condition = item.Condition,
					ReduceAmount = item.ReduceAmount,
					ReduceRate = item.ReduceRate,
					ReduceMax = item.ReduceMax,
					CreatedDate = DateTime.Now,
					StartDate = item.StartDate,
					EndDate = item.EndDate,
					Description = item.Description,
					Status = 1,
					Id_PromotionType = item.Id_PromotionType,
				};
				await _context.Promotions.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public  async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Promotions.FindAsync(Id);
				await Task.FromResult<Promotion>(_context.Promotions.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public  async Task<List<PromotionVM>> GetActiveAsync(Guid? IdType)
		{
			if (IdType != null)
			{
				return await _context.Promotions.ProjectTo<PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Id_PromotionType == IdType).ToListAsync();
			}
			return await _context.Promotions.ProjectTo<PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public  async Task<List<PromotionVM>> GetAsync(Guid? IdType)
		{
			if (IdType != null)
			{
				return await _context.Promotions.ProjectTo<PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_PromotionType == IdType).ToListAsync();
			}
			return await _context.Promotions.ProjectTo<PromotionVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public  async Task<PromotionVM> GetByIdAsync(Guid? Id, string? code)
		{
			try
			{
				if (Id != null)
				{
					return await _context.Promotions.ProjectTo<PromotionVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
				}
				return await _context.Promotions.ProjectTo<PromotionVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Code == code);
			}
			catch { return null; }
		}

		public  async Task<bool> UpdateAsync(PromotionVM item)
		{
			try
			{
				var obj = await _context.Promotions.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Condition = item.Condition;
				obj.ReduceAmount = item.ReduceAmount;
				obj.ReduceRate = item.ReduceRate;
				obj.ReduceMax = item.ReduceMax;
				obj.StartDate = item.StartDate;
				obj.EndDate = item.EndDate;
				obj.Description = item.Description;
				obj.Status = item.Status;
				obj.Id_PromotionType = item.Id_PromotionType;

				await Task.FromResult<Promotion>(_context.Promotions.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}catch (Exception ex) { return false; }
		}
	}
}
