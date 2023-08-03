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
	public class Collection_BookServive : ICollection_BookService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public Collection_BookServive(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(Collection_BookVM item)
		{
			try
			{
				var obj = new Collection_Book()
				{
					Id = item.Id,
					Name = item.Name,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Collection_Books.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Collection_Books.FindAsync(Id);
				await Task.FromResult<Collection_Book>(_context.Collection_Books.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<Collection_BookVM>> GetActiveAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Collection_Books.ProjectTo<Collection_BookVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Collection_Books.ProjectTo<Collection_BookVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<Collection_BookVM>> GetAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Collection_Books.ProjectTo<Collection_BookVM>(_mapper.ConfigurationProvider).Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Collection_Books.ProjectTo<Collection_BookVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<Collection_BookVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.Collection_Books.ProjectTo<Collection_BookVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}
			catch { return null; }
		}

		public async Task<bool> UpdateAsync(Collection_BookVM item)
		{
			try
			{
				var obj = await _context.Collection_Books.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Status = item.Status;
				await Task.FromResult<Collection_Book>(_context.Collection_Books.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
