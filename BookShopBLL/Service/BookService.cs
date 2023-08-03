using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopBLL.IService;
using BookShopBLL.ViewModel;
using BookShopDAL.ApplicationDBContext;
using BookShopDAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BookShopBLL.Service
{
	public class BookService : IBookService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public BookService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}
		public async Task<bool> AddAsync(BookVM item)
		{
			try
			{
				var obj = new Book()
				{
					Id = item.Id,
					ISBN = item.ISBN,
					Title = item.Title,
					Price = item.Price,
					ImportPrice = item.ImportPrice,
					Reader = item.Reader,
					Pages = item.Pages,
					PublicationDate = item.PublicationDate,
					PageSize = item.PageSize,
					Cover = item.Cover,
					Weight = item.Weight,
					Description = item.Description,
					Id_Publisher = item.Id_Publisher,
					Id_Brand = item.Id_Brand,
					Id_Collection = item.Id_Collection,
					Id_Genre = item.Id_Genre,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Books.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Books.FindAsync(Id);
				await Task.FromResult<Book>(_context.Books.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<BookVM>> GetActiveAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Books.ProjectTo<BookVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Title.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Books.ProjectTo<BookVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<BookVM>> GetAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Books.ProjectTo<BookVM>(_mapper.ConfigurationProvider).Where(c => c.Title.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Books.ProjectTo<BookVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<BookVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.Books.ProjectTo<BookVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}catch (Exception ex) { return null; }
		}

		public async Task<bool> UpdateAsync(BookVM item)
		{
			try
			{
				var obj = await _context.Books.FindAsync(item.Id);
				obj.ISBN = item.ISBN;
				obj.Title = item.Title;
				obj.Price = item.Price;
				obj.ImportPrice = item.ImportPrice;
				obj.Reader = item.Reader;
				obj.Pages = item.Pages;
				obj.PublicationDate = item.PublicationDate;
				obj.PageSize = item.PageSize;
				obj.Cover = item.Cover;
				obj.Weight = item.Weight;
				obj.Description = item.Description;
				obj.Id_Publisher = item.Id_Publisher;
				obj.Id_Collection = item.Id_Collection;
				obj.Id_Brand = item.Id_Brand;
				obj.Id_Genre = item.Id_Genre;
				obj.Status = item.Status;

				await Task.FromResult<Book>(_context.Books.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
