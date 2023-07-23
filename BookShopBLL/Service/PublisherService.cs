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
	public class PublisherService : IPublisherService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public PublisherService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(PublisherVM item)
		{
			try
			{
				var obj = new Publisher()
				{
					Id = item.Id,
					Name = item.Name,
					Index = item.Index,
					Description = item.Description,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Publishers.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Publishers.FindAsync(Id);
				await Task.FromResult<Publisher>(_context.Publishers.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<PublisherVM>> GetActiveAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Publishers.ProjectTo<PublisherVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Publishers.ProjectTo<PublisherVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<PublisherVM>> GetAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Publishers.ProjectTo<PublisherVM>(_mapper.ConfigurationProvider).Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Publishers.ProjectTo<PublisherVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<PublisherVM> GetByIdAsync(Guid Id)
		{
			return await _context.Publishers.ProjectTo<PublisherVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
		}

		public async Task<bool> UpdateAsync(PublisherVM item)
		{
			try
			{
				var obj = await _context.Publishers.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Index = item.Index;
				obj.Description = item.Description;
				obj.Status = item.Status;

				await Task.FromResult<Publisher>(_context.Publishers.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
