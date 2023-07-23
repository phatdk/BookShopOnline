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
	public class Promotion_TypeService : IPromotion_TypeService
	{
		BookShopDBContext _context;
		IMapper _mapper;
        public Promotion_TypeService(IMapper mapper)
        {
            _context = new BookShopDBContext();
			_mapper = mapper;
        }
        public  async Task<bool> AddAsync(Promotion_TypeVM item)
		{
			try
			{
				var obj = new Promotion_Type() 
				{
					Id = item.Id,
					Name = item.Name,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Promotion_Types.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}catch (Exception ex) { return false; }
		}

		public async Task< bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Promotion_Types.FindAsync(Id);
				await Task.FromResult<Promotion_Type>(_context.Promotion_Types.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}catch (Exception ex) { return false; }
		}

		public  async Task<List<Promotion_TypeVM>> GetActiveAsync()
		{
			return await _context.Promotion_Types.ProjectTo<Promotion_TypeVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public  async Task<List<Promotion_TypeVM>> GetAsync()
		{
			return await _context.Promotion_Types.ProjectTo<Promotion_TypeVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task< Promotion_TypeVM> GetByIdAsync(Guid Id)
		{
			return await _context.Promotion_Types.ProjectTo<Promotion_TypeVM>(_mapper.ConfigurationProvider).FirstAsync(c=>c.Id == Id);
		}

		public  async Task<bool> UpdateAsync(Promotion_TypeVM item)
		{
			try
			{
				var obj = await _context.Promotion_Types.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Status = item.Status;

				await Task.FromResult<Promotion_Type>(_context.Promotion_Types.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}catch (Exception ex) { return false; }
		}
	}
}
