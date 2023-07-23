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
	public class Book_PromotionService : IBook_PromotionService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public Book_PromotionService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}
		public async Task<bool> AddAsync(List<Book_PromotionVM> list)
		{
			try
			{
				var listobj = new List<Book_Promotion>();
				foreach (var item in list)
				{
					var obj = new Book_Promotion()
					{
						Id_Book = item.Id_Book,
						Id_Promotion = item.Id_Promotion,
						Index = item.Index,
						CreatedDate = DateTime.Now,
						Status = 1,
					};
					listobj.Add(obj);
				}
				await _context.Book_Promotions.AddRangeAsync(listobj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid? IdBook, Guid? IdPromotion)
		{
			try
			{
				if (IdBook != null && IdPromotion == null)
				{
					var list = await _context.Book_Promotions.FirstAsync(c => c.Id_Book == IdBook);
					_context.Book_Promotions.RemoveRange(list);
					await _context.SaveChangesAsync();
				}
				else if (IdPromotion != null && IdBook == null)
				{
					var list = await _context.Book_Promotions.FirstAsync(c => c.Id_Promotion == IdPromotion);
					_context.Book_Promotions.RemoveRange(list);
					await _context.SaveChangesAsync();
				}
				else
				{
					var obj = _context.Book_Promotions.First(c => c.Id_Book == IdBook && c.Id_Promotion == IdPromotion);
					await Task.FromResult<Book_Promotion>(_context.Book_Promotions.Remove(obj).Entity);
					await _context.SaveChangesAsync();
				}
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<Book_PromotionVM>> GetActiveAsync(Guid? IdBook, Guid? IdPromotion)
		{
			if (IdBook != Guid.Empty || IdBook != null && IdPromotion == null)
			{
				return await _context.Book_Promotions.ProjectTo<Book_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Id_Book == IdBook).ToListAsync();
			}
			else if (IdPromotion != Guid.Empty || IdPromotion != null && IdBook == null)
			{
				return await _context.Book_Promotions.ProjectTo<Book_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1 && c.Id_Promotion == IdPromotion).ToListAsync();
			}
			else return await _context.Book_Promotions.ProjectTo<Book_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<Book_PromotionVM>> GetAsync(Guid? IdBook, Guid? IdPromotion)
		{
			if (IdBook != Guid.Empty || IdBook != null && IdPromotion == null)
			{
				return await _context.Book_Promotions.ProjectTo<Book_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Book == IdBook).ToListAsync();
			}
			else if (IdPromotion != Guid.Empty || IdPromotion != null && IdBook == null)
			{
				return await _context.Book_Promotions.ProjectTo<Book_PromotionVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Promotion == IdPromotion).ToListAsync();
			}
			else return await _context.Book_Promotions.ProjectTo<Book_PromotionVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<Book_PromotionVM> GetByIdAsync(Guid? IdBook, Guid? IdPromotion)
		{
			return await _context.Book_Promotions.ProjectTo<Book_PromotionVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id_Book == IdBook && c.Id_Promotion == IdPromotion);
		}

		public async Task<bool> UpdateAsync(Book_PromotionVM item)
		{
			try
			{
				var obj = await _context.Book_Promotions.FirstAsync(c => c.Id_Promotion == item.Id_Promotion && c.Id_Book == item.Id_Book);
				obj.Id_Book = item.Id_Book;
				obj.Id_Promotion = item.Id_Promotion;
				obj.Index = item.Index;
				obj.Status = item.Status;

				await Task.FromResult<Book_Promotion>(_context.Book_Promotions.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
