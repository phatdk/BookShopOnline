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
	public class Book_AuthorService : IBook_AuthorService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public Book_AuthorService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}
		public async Task<bool> AddAsync(List<Book_AuthorVM> list)
		{
			try
			{
				var listobj = new List<Book_Author>();
				foreach (var item in list)
				{
					var obj = new Book_Author()
					{
						Id_Book = item.Id_Book,
						Id_Author = item.Id_Author,
					};
					listobj.Add(obj);
				}
				await _context.Book_Authors.AddRangeAsync(listobj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid IdBook, Guid? IdAuthor)
		{
			try
			{
				if (IdAuthor == null)
				{
					var obj = await _context.Book_Authors.Where(c => c.Id_Book == IdBook).ToListAsync();
					_context.Book_Authors.RemoveRange(obj);
					await _context.SaveChangesAsync();
				}
				else
				{
					var obj = await _context.Book_Authors.FirstAsync(c => c.Id_Book == IdBook && c.Id_Author == IdAuthor);
					await Task.FromResult<Book_Author>(_context.Book_Authors.Remove(obj).Entity);
					await _context.SaveChangesAsync();
				}
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<Book_AuthorVM>> GetAsync(Guid? IdBook, Guid? IdAuthor)
		{
			var list = await _context.Book_Authors.ProjectTo<Book_AuthorVM>(_mapper.ConfigurationProvider).ToListAsync();
			if (IdBook != Guid.Empty || IdBook != null && IdAuthor == null)
			{
				list = await _context.Book_Authors.ProjectTo<Book_AuthorVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Book == IdBook).ToListAsync();
			}
			else if (IdAuthor != Guid.Empty || IdAuthor != null && IdBook == null)
			{
				list = await _context.Book_Authors.ProjectTo<Book_AuthorVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Author == IdAuthor).ToListAsync();
			}
			else return list;
			return list;
		}

		public async Task<Book_AuthorVM> GetByIdAsync(Guid IdBook, Guid? IdAuthor)
		{
			return await _context.Book_Authors.ProjectTo<Book_AuthorVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id_Book == IdBook && c.Id_Author == IdAuthor);
		}

		public async Task<bool> UpdateAsync(Book_AuthorVM item)
		{
			try
			{
				var obj = await _context.Book_Authors.FirstAsync(c => c.Id_Book == item.Id_Book && c.Id_Author == item.Id_Author);

				obj.Id_Book = item.Id_Book;
				obj.Id_Author = item.Id_Author;

				await Task.FromResult<Book_Author>(_context.Book_Authors.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
