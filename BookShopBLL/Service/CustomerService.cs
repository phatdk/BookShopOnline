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
	public class CustomerService : ICustomerService
	{
		BookShopDBContext _context;
		IMapper _mapper;
		public CustomerService(IMapper mapper)
		{
			_context = new BookShopDBContext();
			_mapper = mapper;
		}
		public async Task<bool> AddAsync(CustomerVM item)
		{
			try
			{
				var obj = new Customer()
				{
					Id = item.Id,
					Name = item.Name,
					Birth = item.Birth,
					Gender = item.Gender,
					Address = item.Address,
					Phones = item.Phones,
					WalletPoint = 0,
					Email = item.Email,
					Password = item.Password,
					CreatedDate = DateTime.Now,
					Status = 1,
				};
				await _context.Customers.AddAsync(obj);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			try
			{
				var obj = await _context.Customers.FindAsync(Id);
				await Task.FromResult<Customer>(_context.Customers.Remove(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}

		public async Task<List<CustomerVM>> GetActiveAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Customers.ProjectTo<CustomerVM>(_mapper.ConfigurationProvider).Where(c => c.Name.ToLower().Contains(name.ToLower()) && c.Status == 1).ToListAsync();
			}
			return await _context.Customers.ProjectTo<CustomerVM>(_mapper.ConfigurationProvider).Where(c => c.Status == 1).ToListAsync();
		}

		public async Task<List<CustomerVM>> GetAsync(string? name)
		{
			if (name != null)
			{
				return await _context.Customers.ProjectTo<CustomerVM>(_mapper.ConfigurationProvider).Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
			}
			return await _context.Customers.ProjectTo<CustomerVM>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<CustomerVM> GetByIdAsync(Guid? Id, string? email, int status)
		{
			if (Id != null)
			{
				return await _context.Customers.ProjectTo<CustomerVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Id == Id && c.Status == status);
			}
			return await _context.Customers.ProjectTo<CustomerVM>(_mapper.ConfigurationProvider).FirstAsync(c => c.Email.ToLower().Equals(email.ToLower()));
		}

		public async Task<bool> UpdateAsync(CustomerVM item)
		{
			try
			{
				var obj = await _context.Customers.FindAsync(item.Id);
				obj.Name = item.Name;
				obj.Birth = item.Birth;
				obj.Gender = item.Gender;
				obj.Address = item.Address;
				obj.Phones = item.Phones;
				obj.WalletPoint = item.WalletPoint;
				obj.Email = item.Email;
				obj.Password = item.Password;
				obj.Status = item.Status;

				await Task.FromResult<Customer>(_context.Customers.Update(obj).Entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex) { return false; }
		}
	}
}
