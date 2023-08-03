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
using System.Xml.Linq;

namespace BookShopBLL.Service
{
	public class GenreService : IGenreService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public GenreService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}
		public async Task<bool> AddAsync(GenreVM item)
		{
			try
			{
				var obj = new Genre()
				{
					Id = item.Id,
					Name = item.Name,
					Index = item.Index,
					Description = item.Description,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Genres.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Genres.FindAsync(Id);
				await Task.FromResult<Genre>(_context.Genres.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<GenreVM>> GetActiveAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Genres.ProjectTo<GenreVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Genres.ProjectTo<GenreVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<GenreVM>> GetAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Genres.ProjectTo<GenreVM>(_mapper.ConfigurationProvider).Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Genres.ProjectTo<GenreVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<GenreVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.Genres.ProjectTo<GenreVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}
			catch { return null; }
		}

		public async Task<bool> UpdateAsync(GenreVM item)
		{
			try
			{
				var obj = await _context.Genres.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Index = item.Index;
				obj.Description = item.Description;
				obj.Status = item.Status;

				await Task.FromResult<Genre>(_context.Genres.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
