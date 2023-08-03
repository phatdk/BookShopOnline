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
	public class AuthorService : IAuthorService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public AuthorService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}
		public async Task<bool> AddAsync(AuthorVM item)
		{
			try
			{
				var obj = new Author()
				{
					Id = item.Id,
					Name = item.Name,
					Index = item.Index,
					CreatedDate = DateTime.Now,
					Status = 1,
				};

				await _context.Authors.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Authors.FindAsync(Id);
				await Task.FromResult(_context.Authors.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<AuthorVM>> GetActiveAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Authors.ProjectTo<AuthorVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Authors.ProjectTo<AuthorVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<AuthorVM>> GetAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Authors.ProjectTo<AuthorVM>(_mapper.ConfigurationProvider).Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Authors.ProjectTo<AuthorVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<AuthorVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.Authors.ProjectTo<AuthorVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}catch (Exception ex) { return null; }
		}

		public async Task<bool> UpdateAsync(AuthorVM item)
		{
			try
			{
				var obj = await _context.Authors.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Index = item.Index;
				obj.Status = item.Status;
				await Task.FromResult(_context.Authors.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
