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
	public class EvaluateService : IEvaluateService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public EvaluateService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(EvaluateVM item)
		{
			try
			{
				var obj = new Evaluate()
				{
					Id = item.Id,
					Point = item.Point,
					Content = item.Content,
					CreatedDate = DateTime.Now,
					status = 1,
					Id_Customer = item.Id_Customer,
					Id_Book = item.Id_Book,
				};
				await _context.Evaluates.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Evaluates.FindAsync(Id);
				await Task.FromResult<Evaluate>(_context.Evaluates.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<EvaluateVM>> GetAsync(Guid? IdBook, Guid? IdCustomer)
		{
			if (IdBook != null && IdCustomer == null)
			{
				return await _context.Evaluates.ProjectTo<EvaluateVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Book == IdBook).ToListAsync();
			}
			else if (IdCustomer != null && IdBook == null)
			{
				return await _context.Evaluates.ProjectTo<EvaluateVM>(_mapper.ConfigurationProvider).Where(c => c.Id_Customer == IdCustomer).ToListAsync();
			}
			return await _context.Evaluates.ProjectTo<EvaluateVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<EvaluateVM> GetByIdAsync(Guid Id)
		{
			return await _context.Evaluates.ProjectTo<EvaluateVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
		}

		public async Task<bool> UpdateAsync(EvaluateVM item)
		{
			try
			{
				var obj = await _context.Evaluates.FindAsync(item.Id);
				obj.Point = item.Point;
				obj.Content = item.Content;
				obj.status = item.status;

				await Task.FromResult<Evaluate>(_context.Evaluates.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
