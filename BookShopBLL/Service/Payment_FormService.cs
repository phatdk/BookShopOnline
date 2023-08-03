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
	public class Payment_FormService : IPayment_FormService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public Payment_FormService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(Payment_FormVM item)
		{
			try
			{
				var obj = new Payment_Form()
				{
					Id = item.Id,
					Name = item.Name,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Payment_Forms.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Payment_Forms.FindAsync(Id);
				await Task.FromResult<Payment_Form>(_context.Payment_Forms.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<Payment_FormVM>> GetActiveAsync()
		{
			return await _context.Payment_Forms.ProjectTo<Payment_FormVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<Payment_FormVM>> GetAsync()
		{
			return await _context.Payment_Forms.ProjectTo<Payment_FormVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<Payment_FormVM> GetByIdAsync(Guid Id)
		{
			try
			{
				return await _context.Payment_Forms.ProjectTo<Payment_FormVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id);
			}
			catch { return null; }
		}

		public async Task<bool> UpdateAsync(Payment_FormVM item)
		{
			try
			{
				var obj = await _context.Payment_Forms.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Status = item.Status;

				await Task.FromResult<Payment_Form>(_context.Payment_Forms.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
