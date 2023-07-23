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
	public class BrandService : IBrandService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public BrandService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(BrandVM item)
		{
			try
			{
				var obj = new Brand()
				{
					Id = item.Id,
					Name = item.Name,
					Description = item.Description,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Brands.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Brands.FindAsync(Id);
				await Task.FromResult<Brand>(_context.Brands.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<BrandVM>> GetActiveAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Brands.ProjectTo<BrandVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Brands.ProjectTo<BrandVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<BrandVM>> GetAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Brands.ProjectTo<BrandVM>(_mapper.ConfigurationProvider).Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Brands.ProjectTo<BrandVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<BrandVM> GetByIdAsync(Guid Id)
		{
			return await _context.Brands.ProjectTo<BrandVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
		}

		public async Task<bool> UpdateAsync(BrandVM item)
		{
			try
			{
				var obj = await _context.Brands.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Description = item.Description;
				obj.Status = item.Status;
				await Task.FromResult<Brand>(_context.Brands.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
