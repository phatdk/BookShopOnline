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
	public class CommentService : ICommentService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public CommentService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(CommentVM item)
		{
			try
			{
				var obj = new Comment()
				{
					Id = item.Id,
					Content = item.Content,
					CreatedDate = DateTime.Now,
					Id_Book = item.Id_Book,
					Id_Customer = item.Id_Customer,
					Id_Parents = item.Id_Parents,
				};
				await _context.Comments.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj =await _context.Comments.FindAsync(Id);
				await Task.FromResult<Comment>(_context.Comments.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<CommentVM>> GetAsync(Guid? IdBook, Guid? IdCustommer, Guid? IdParents)
		{
			if (IdBook != null && IdCustommer == null)
			{
				return await _context.Comments.ProjectTo<CommentVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Book == IdBook).ToListAsync();
			}
			else if (IdCustommer != null && IdBook == null)
			{
				return await _context.Comments.ProjectTo<CommentVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustommer).ToListAsync();
			}
			else if (IdParents != null)
			{
				return await _context.Comments.ProjectTo<CommentVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Parents == IdParents).ToListAsync();
			}
			else return await _context.Comments.ProjectTo<CommentVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<CommentVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.Comments.ProjectTo<CommentVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}catch (Exception ex) { return null; }
		}

		public async Task<bool> UpdateAsync(CommentVM item)
		{
			try
			{
				var obj = await _context.Comments.FindAsync(item.Id);
				obj.Content = item.Content;

				await Task.FromResult<Comment>(_context.Comments.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
