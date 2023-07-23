using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopBLL.AutoMapper;
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
	public class AdminService : IAdminService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public AdminService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}
		public async Task<bool> AddAsync(AdminVM item)
		{
			try
			{
				var obj = new Admin()
				{
					Id = item.Id,
					Email = item.Email,
					Password = item.Password,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Admins.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Admins.FindAsync(Id);
				await Task.FromResult(_context.Admins.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<AdminVM>> GetActiveAsync()
		{
			return await _context.Admins.ProjectTo<AdminVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<AdminVM>> GetAsync()
		{
			return await _context.Admins.ProjectTo<AdminVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<AdminVM> GetByIdAsync(Guid? Id, string? email, int status)
		{
			if (Id != null)
			{
				return await _context.Admins.ProjectTo<AdminVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id && c.Status == status);
			}
			return await _context.Admins.ProjectTo<AdminVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Email.ToLower().Equals(email.ToLower()) && c.Status == status);
		}

		public async Task<bool> UpdateAsync(AdminVM item)
		{
			try
			{
				var obj = await _context.Admins.FindAsync(item.Id);
				obj.Email = item.Email;
				obj.Password = item.Password;
				obj.Status = item.Status;
				await Task.FromResult(_context.Admins.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
