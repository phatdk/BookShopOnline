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
	public class NewsService : INewsService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public NewsService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(NewsVM item)
		{
			try
			{
				var obj = new News()
				{
					Id = item.Id,
					Title = item.Title,
					Content = item.Content,
					Description = item.Description,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.News.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.News.FindAsync(Id);
				await Task.FromResult<News>(_context.News.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<NewsVM>> GetAsync()
		{
			return await _context.News.ProjectTo<NewsVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<NewsVM> GetByIdAsync(Guid Id)
		{
			return await _context.News.ProjectTo<NewsVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
		}

		public async Task<bool> UpdateAsync(NewsVM item)
		{
			try
			{
				var obj = await _context.News.FindAsync(item.Id);
				obj.Description = item.Description;
				obj.Content = item.Content;
				obj.Title = item.Title;

				await Task.FromResult<News>(_context.News.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception e) { return false; }
		}
	}
}
